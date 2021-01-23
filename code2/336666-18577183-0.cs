        /// <summary>
        /// given an non-empty input array of integers, this method returns the largest contiguous sum
        /// </summary>
        /// <param name="inputArray">the non-empty input array of integeres</param>
        /// <returns>int, the largest contiguous sum</returns>
        /// <remarks>time complexity O(n)</remarks>
        
        static int GetLargestContiguousSum(int[] inputArray)
        {
            //find length of the string, if empty throw an exception            
            if (inputArray.Length == 0)
                throw new ArgumentException("the input parameter cannot be an empty array");
            int maxSum = 0;
            int currentSum = 0;
            maxSum = currentSum = inputArray[0];
            for (int i = 1; i < inputArray.Length; i++) //skip i=0 as currentSum=inputArray[0].
            {
                currentSum = Math.Max(currentSum + inputArray[i], inputArray[i]);
                maxSum = Math.Max(currentSum, maxSum);
            }
            return maxSum;
        }
