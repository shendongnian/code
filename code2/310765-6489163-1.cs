            private static void GetCount(int[,] Positions)
            {
                List<int> x = new List<int>();
                List<int> y = new List<int>();
                for (int i = 0; i < Positions.Length/2; i++)
                {
                    x.Add(Positions[i, 0]);
                    y.Add(Positions[i, 1]);
                }
                int result = (x.Distinct().Count() * 8) + (y.Distinct().Count() * 8);
                Console.WriteLine(result);
            }
