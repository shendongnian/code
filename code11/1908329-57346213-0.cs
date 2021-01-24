     static void row_sum(int[][] arr)
     {
        int i, j, sum = 0;
        // finding the row sum 
        for (i = 0; i < arr.Length; ++i)
        {
            for (j = 0; j < arr[i].Length; ++j)
            {
                // Add the element 
                sum = sum + arr[i][j];
            }
            // Print the row sum 
            Console.WriteLine("Sum of the row " +
                                 i + " = " + sum);
            // Reset the sum 
            sum = 0;
        }
     }
