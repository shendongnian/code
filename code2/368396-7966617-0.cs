    static void Main(string[] args)
            {
                int[][] multi = new int[3][];
                multi[0] = new int[3] { 1, 2, 3 };
                multi[1] = new int[3] { 5, 10, 20 };
                multi[2] = new int[3] { 3, 4, 8 };
                List<int[]> t = multi.ToList();
                List<int[]> avg = t.OrderBy(x => GetAvgDifference(x)).Take(1).ToList();
            }
    
            public static double GetAvgDifference(int[] arr)
            {
                List<int> differences = new List<int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i; j < arr.Length; j++)
                    {
                        int difference = arr[i] - arr[j];
    
                        if (difference < 1)
                        {
                            differences.Add(difference * -1);
                        }
                        else
                        {
                            differences.Add(difference);
                        }
                    }
                }
    
                return differences.Average();
            }
