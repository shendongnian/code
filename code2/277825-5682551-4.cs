    public static void RemoveIntsBefore(int i) 
        {
            int[] RowOfints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1,2 };                     
            
            Console.WriteLine("OUTPUT");
            foreach (var item in Enumerable.Range(i-1, RowOfints.Length + 1 - i).ToArray())
            {
                Console.WriteLine(RowOfints[item]);
            }
            Console.ReadLine();
        
        }
