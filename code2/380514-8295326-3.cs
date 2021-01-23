            int total = 0, partSum = 0, partIndex = 0;
            int noOfParts = 3; //Initialize the no. of parts
            int[] input = { 10, 8, 8, 7, 6, 6, 6, 5 };
            int[] result = new int[noOfParts]; //Initialize result array with no. of locations equal to no. of parts, to store partSums
            foreach (int i in input) //Calculate the total of input array values
            {
                total += i;
            }
            int threshold = (total / noOfParts) - (total / input.Length) / 2; //Calculate a minimum threshold value for partSum
            for (int j = input.Length - 1; j > -1; j--)
            {
                partSum += input[j]; //Add array values to partSum incrementally
                if (partSum >= threshold) //If partSum reaches the threshold value, add it to result[] and reset partSum  
                {
                    result[partIndex] = partSum;
                    partIndex += 1;
                    partSum = 0;
                    continue;
                }
            }
            if (partIndex < noOfParts) //If no. of parts in result[] is less than the no. of parts required, add the remaining partSum value
            {
                result[partIndex] = partSum;
            }
            Array.Reverse(result);
            foreach (int k in result)
            {
                Console.WriteLine(k);
            }
            Console.Read();     
