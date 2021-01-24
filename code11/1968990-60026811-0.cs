                string[] words = new string[4] { "apple", "app", "apricot", "stone" };
                int[] output = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    output[i] = words.GroupBy(s => (s.Length >= i + 1 ? s.Substring(0, i + 1) : string.Empty))
                                     .Select(x => new { x.Key, Count = x.Count() })
                                     .Where(x => x.Key != string.Empty).Count();
                    Console.WriteLine(output[i]);
                }
            
