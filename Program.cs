using System;

namespace RoomAllegation
{
    internal class Program
    {
        #region Privates
        private static void Main(string[] args)
        {
            //Test Case 1
            RoomAllegation(9, 0);

            //Test Case 2
            RoomAllegation(9, 3); //1+3, 1+3, 1+3  

            //Test Case 3
            RoomAllegation(9, 4); //1+3, 1+3, 1+3, 1+0  

            //Test Case 4
            RoomAllegation(6, 2); //1+3, 1+3

            //Test Case 5
            RoomAllegation(0, 2); //2+0,

            //Test Case 6
            RoomAllegation(0, 10); //4+0, 4+0, 2+0

            //Test Case 7
            RoomAllegation(10, 6); //1+3, 1+3, +0  

            //Test Case 8
            RoomAllegation(4, 12); //1+3, 3+1, 4+0, 4+0

            //Test Case 9
            RoomAllegation(11, 6); //Maximum Alowed 16 Total Member Count Morethen 16 So not acceptable

            //Test Case 10
            RoomAllegation(11, 2); //Adult And Child Ratio Not Equal

            //Test Case 11
            RoomAllegation(10, 4); //1+3, 1+3, 1+3, 1+1

            Console.ReadKey();
        }

        private static void RoomAllegation(int nChild, int nAdult)
        {
            int nTotalMember = nChild + nAdult;

            int nRooms = nTotalMember / 4;

            if(nTotalMember % 4 != 0) nRooms++;

            if(ErrorHandler(nChild, nAdult)) PreparePattern(nChild, nAdult, nRooms);

            Console.WriteLine("________________________");
        }

        private static bool ErrorHandler(int nChild, int nAdult)
        {
            if(nAdult == 0)
            {
                Console.WriteLine("Adult 0 not acceptable");
                return false;
            }

            if(nChild + nAdult > 16)
            {
                Console.WriteLine("Maximum Alowed 16 Total Member Count More Then 16 not acceptable");
                return false;
            }

            if(nChild > nAdult * 3)
            {
                Console.WriteLine("Adult And Child Ratio Not Equal");
                return false;
            }

            return true;
        }

        private static void PreparePattern(int nChildCount, int nAdultCount, int nTotalRoom)
        {
            int nTempChildCount = nChildCount;
            int nTempAdultCount = nAdultCount;
            int nTempRoomsCount = nTotalRoom;

            for(int i = 0; i < nTempRoomsCount; i++)
            {
                if(nTempChildCount >= 3)
                {
                    Console.WriteLine("Adult 1 Child 3");

                    nTempChildCount -= 3;
                    nTempAdultCount--;
                }
                else if(nTempChildCount > 0)
                {
                    int nTemp = 4 - nTempChildCount;

                    Console.WriteLine($"Adult {nTemp} Child {nTempChildCount}");

                    nTempAdultCount -= nTemp;
                    nTempChildCount -= nTempChildCount;
                }
                else
                {
                    int nTemp = nTempAdultCount > 4 ? 4 : nTempAdultCount;
                    Console.WriteLine($"Adult {nTemp} Child 0");

                    nTempAdultCount -= 4;
                }
            }
        }
        #endregion
    }
}