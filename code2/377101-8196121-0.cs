            var records = new int[][] { new int[] { 1, 1, 2 }, new int[] { 1, 2, 3 }, new int[] { 2, 3, 1 } };
            var items = new int[] { 3, 1 };
            var userId = 1;
            
            var result = items.Select(i =>
            {
                // When there's a match
                if (records.Any(r => r[0] == userId && r[1] == i))
                {
                    // Return all numbers
                    return records.Where(r => r[0] == userId && r[1] == i).Select(r => r[2]);
                }
                else
                {
                   // Just return 0
                    return new int[] { 0 };
                }
            }).SelectMany(r => r); // flatten the int[][] to int[]
            
            // output
            result.ToList().ForEach(i => Console.Write("{0} ", i));
            Console.ReadKey(true);
