    int[][] TValue = new int[][]
                    {
                        new int[] {1,2,3,4,5 },
                        new int[] {2,4,6,8,10 },
                        new int[] {3,6,9,12,15 }
                    };
                    Console.WriteLine("Avg[0] => " + TValue.Select(x => x[0]).Average());
