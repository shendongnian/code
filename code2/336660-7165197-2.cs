    /*  Initialize:
                max_so_far = 0
                max_ending_here = 0
            Loop for each element of the array
                (a) max_ending_here = max_ending_here + a[i]
                (b) if(max_ending_here < 0)
                        max_ending_here = 0
                (c) if(max_so_far < max_ending_here)
                        max_so_far = max_ending_here
            return max_so_far*/
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            namespace ConsoleApplication3
            {
                class Program
                {
                    static void Main(string[] args)
                    {
                        int[] array = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
                        int[] largestSubArray;
                        largestSubArray = Max_Array(array);
                        Console.WriteLine();
                        Console.WriteLine("Subarray is :");
                        foreach (int numb in largestSubArray)
                            Console.WriteLine(numb);
                        Console.ReadKey();
                    }
                    //Max_Array function will calculate the largest contigent array
                    //sum and then find out startIndex and endIndex of sub array
                    //within for loop.Using this startIndex and endIndex new subarray
                    //is created with the name of largestSubArray and values are copied                           
                    //from original array. 
                    public static int[] Max_Array(int[] array)
                    {
                        int[] largestSubArray;
                        int max_so_far = 0, max_ending_here = 0, startIndex = 0,
                            endIndex = 0;
                        for (int i = 0, j = 0; i < array.Length; i++)
                        {
                            max_ending_here += array[i];
                            if (max_ending_here <= 0)
                            {
                                max_ending_here = 0;
                            }
                            if (max_so_far < max_ending_here)
                            {
                                if (max_ending_here == array[i])
                                { startIndex = i; }
                                max_so_far = max_ending_here;
                                endIndex = i;
                            }
                        }
                        Console.WriteLine("Largest sum is: {0}", max_so_far);
                        largestSubArray = new int[(endIndex - startIndex) + 1];
                        Array.Copy(array, startIndex, largestSubArray, 0, (endIndex - startIndex) + 1);
                        return largestSubArray;
                    }
                }
            }
