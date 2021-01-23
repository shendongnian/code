    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RecursiveHashing
    {
        static class Utilities
        {
    
            // used for circular arrays. If my circular array is of size 5 and it's
            // current position is 2 if I shift 3 units to the left I shouls be in index
            // 4 of the array.
            public static int Shift(this int number, int shift, int divisor)
            {
                var tempa = (number + shift) % divisor;
                if (tempa < 0)
                    tempa = divisor + tempa;
                return tempa;
            }
    
        }
        class Program
        {
            const int CHUNCK_SIZE = 4; // split the files in chuncks of 4 bytes
    
            /* 
             * formula that I will use to compute hash
             * 
             *      formula =  sum(chunck) * (a[c]+1)*(a[c-1]+1)*(a[c-2]+1)*(-1^a[c])
             *      
             *          where:
             *              sum(chunk)  = sum of current chunck
             *              a[c]        = current byte
             *              a[c-1]      = last byte
             *              a[c-2]      = last last byte
             *              -1^a[c]     = eather -1 or +1  
             *              
             *      this formula is efficient because I can get the sum of any current index by keeping trak of the overal sum
             *      thus this algorithm should be of order n
             */
    
            static void Main(string[] args)
            {
                Part1(); // Missing implementation to open file for reading
                Part2();
            }
    
    
    
            // fist part compute hashes on first file
            static void Part1()
            {
                // pertend file b reads those bytes
                byte[] FileB = new byte[]{2,3,5,8,2,0,1,0,0,0,1,2,4,5,6,7,8,2,3,4,5,6,7,8,11,};
                
                // create an array where to store the chashes
                // index 0 will use a fast hash algorithm. index 1 will use a more secure hashing algorithm
                Int64[,] hashes = new Int64[(FileB.Length / CHUNCK_SIZE) + 10, 2];
    
                
                // used to track on what index of the file we are at
                int counter = 0;
                byte[] current = new byte[CHUNCK_SIZE + 1]; // circual array  needed to remember the last few bytes
                UInt64[] sum = new UInt64[CHUNCK_SIZE + 1]; // circual array  needed to remember the last sums
                int index = 0; // position where in circular array
    
                int numberOfHashes = 0; // number of hashes created so far
    
    
                while (counter < FileB.Length)
                {
                    int i = 0;
                    for (; i < CHUNCK_SIZE; i++)
                    {
                        if (counter == 0)
                        {
                            sum[index] = FileB[counter];
                        }
                        else
                        {
                            sum[index] = FileB[counter] + sum[index.Shift(-1, CHUNCK_SIZE + 1)];
                        }
                        current[index] = FileB[counter];
                        counter++;
                        
                        if (counter % CHUNCK_SIZE == 0 || counter == FileB.Length)
                        {
                            // get the sum of the last chunk
                            var a = (sum[index] - sum[index.Shift(1, CHUNCK_SIZE + 1)]);
                            Int64 tempHash = (Int64)a;
    
                            // conpute my hash function
                            tempHash = tempHash * ((Int64)current[index] + 1)
                                              * ((Int64)current[index.Shift(-1, CHUNCK_SIZE + 1)] + 1)
                                              * ((Int64)current[index.Shift(-2, CHUNCK_SIZE + 1)] + 1)
                                              * (Int64)(Math.Pow(-1, current[index]));
    
    
                            // add the hashes to the array
                            hashes[numberOfHashes, 0] = tempHash;
                            numberOfHashes++;
    
                            hashes[numberOfHashes, 1] = -1;// later store a stronger hash function
                            numberOfHashes++;
    
                            // MISSING IMPLEMENTATION TO STORE A SECOND STRONGER HASH FUNCTION
    
                            if (counter == FileB.Length)
                                break;
                        }
    
                        index++;
                        index = index % (CHUNCK_SIZE + 1); // if index is out of bounds in circular array place it at position 0
                    }
                }
            }
    
    
            static void Part2()
            {
                // simulate file read of a similar file
                byte[] FileB = new byte[]{1,3,5,8,2,0,1,0,0,0,1,2,4,5,6,7,8,2,3,4,5,6,7,8,11};            
    
                // place where we will place all matching hashes
                Int64[,] hashes = new Int64[(FileB.Length / CHUNCK_SIZE) + 10, 2];
    
    
                int counter = 0;
                byte[] current = new byte[CHUNCK_SIZE + 1]; // circual array
                UInt64[] sum = new UInt64[CHUNCK_SIZE + 1]; // circual array
                int index = 0; // position where in circular array
    
    
    
                while (counter < FileB.Length)
                {
                    int i = 0;
                    for (; i < CHUNCK_SIZE; i++)
                    {
                        if (counter == 0)
                        {
                            sum[index] = FileB[counter];
                        }
                        else
                        {
                            sum[index] = FileB[counter] + sum[index.Shift(-1, CHUNCK_SIZE + 1)];
                        }
                        current[index] = FileB[counter];
                        counter++;
    
                        // here we compute the hash every time and we are missing implementation to 
                        // check if hash is contained by the other file
                        if (counter >= CHUNCK_SIZE)
                        {
                            var a = (sum[index] - sum[index.Shift(1, CHUNCK_SIZE + 1)]);
    
                            Int64 tempHash = (Int64)a;
    
                            tempHash = tempHash * ((Int64)current[index] + 1)
                                              * ((Int64)current[index.Shift(-1, CHUNCK_SIZE + 1)] + 1)
                                              * ((Int64)current[index.Shift(-2, CHUNCK_SIZE + 1)] + 1)
                                              * (Int64)(Math.Pow(-1, current[index]));
    
                            if (counter == FileB.Length)
                                break;
                        }
    
                        index++;
                        index = index % (CHUNCK_SIZE + 1);
                    }
                }
            }
        }
    }
