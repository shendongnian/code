                    String[][] TValue = new String[][]
                    {
                        new String[] {"1.11", "2.11", "3.11" },
                        new String[] {"2.11", "3.11", "4.11" }, 
                        new String[] {"4.11", "5.11", "6.11" }
                    };
                    Console.WriteLine("Avg[0] => {0:F2}", TValue.Select(x => double.Parse(x[0])).Average());
                    Console.WriteLine("Avg[1] => {0:F2}", TValue.Select(x => double.Parse(x[1])).Average());
                    Console.WriteLine("Avg[2] => {0:F2}", TValue.Select(x => double.Parse(x[2])).Average());
