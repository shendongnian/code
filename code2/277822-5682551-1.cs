            int[] RowOfints = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int k = 0; k < RowOfints.Length; k++)
            {
                if (RowOfints.ElementAt(k) < i)
                {
                    RowOfints[k] = i;
                }
            }
            RowOfints = RowOfints.Distinct().ToArray();
    //this part is to write it on console
                //foreach (var item in RowOfints)
                //{
                //    Console.WriteLine(item);
                //}
    
                //Console.ReadLine();
        
        }
