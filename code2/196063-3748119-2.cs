            Pair[] pairs = NewCollection.GetIndex(array, intQuery);
            List<int> minWindow = new List<int>();
            for (int i = 0; i <pairs.Length - 1; i++)
            {
                List<int> first = pairs[i].Position;
                List<int> second = pairs[i + 1].Position;
                int? temp = null;
                int? temp1 = null;
                foreach(int m in first)
                {
                    foreach (int n in second)
                    {
                        if (n > m)
                        {
                            temp = m;
                            temp1 = n;
                        }                        
                    }                    
                }
                if (temp.HasValue && temp1.HasValue)
                {
                    if (!minWindow.Contains((int)temp))
                        minWindow.Add((int)temp);
                    if (!minWindow.Contains((int)temp1))
                        minWindow.Add((int)temp1);
                }
                else
                {
                    Console.WriteLine(" Bad Query array");
                    minWindow.Clear();
                    break;                    
                }
            }
            if(minWindow.Count > 0)
            {
             Console.WriteLine("Minimum Window is :");
             foreach(int i in minWindow)
             {
                 Console.WriteLine(i + " ");
             }
            }
