    foreach (T i in arr)
            {
                if (i.CompareTo(pivot_val) <= 0)
                {
                    
                    loe.Add(i);
                    Console.WriteLine("loe.add " + i.ToString());
                }
                else
                {
                    gt.Add(i);
                    Console.WriteLine("gt.add " + i.ToString());
                }
            }
