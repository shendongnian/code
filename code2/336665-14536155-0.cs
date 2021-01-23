    using System;
    using System.Collections.Generic;
    
    class MaxSumOfSubArray
    {
        static void Main()
        {
            //int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            //maxSubSum(array);
            
            int digits;
            List<int> array = new List<int>();
            Console.WriteLine("Please enter array of integer values. To exit, enter eny key different than 0..9");
    
            while (int.TryParse(Console.ReadLine(), out digits))
            {
                array.Add(digits);
            }
            
            maxSubSum(array);
        }
    
        public static void maxSubSum(List<int> arr)
        {
            int maxSum = 0;
            int currentSum = 0;
            int i = 0;
            int j = 0;
            int seqStart=0;
            int seqEnd=0;
            while (j < arr.Count)
            {
                currentSum = currentSum + arr[j];
    
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    seqStart = i;
                    seqEnd = j;
                }
                else if (currentSum < 0)
                {
                    i = j + 1;
                    currentSum = 0;
                }
                j++;
            }
            Console.Write("The sequence of maximal sum in given array is: {");
            for (int seq = seqStart; seq <= seqEnd; seq++)
            {
                Console.Write(arr[seq] + " ");
            }
            Console.WriteLine("\b}");
            Console.WriteLine("The maximum sum of subarray is: {0}", maxSum);
        }
    }
