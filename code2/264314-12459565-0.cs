        public class Range
        {
            public static List<int> range(int a, int b)
            {
                List<int> result = new List<int>();
    
                for(int i = a; i <= b; i++)
                {
                    result.Add(i);
                }
    
                return result;
            }
    
            public static int[] Understand(string input)
            {
                return understand(input).ToArray();
            }
    
            public static List<int> understand(string input)
            {
                List<int> result = new List<int>();
                string[] lines = input.Split(new char[] {';', ','});
    
                foreach (string line in lines)
                {
                    try
                    {
                        int temp = Int32.Parse(line);
                        result.Add(temp);
                    }
                    catch
                    {
                        string[] temp = line.Split(new char[] { '-' });
                        int a = Int32.Parse(temp[0]);
                        int b = Int32.Parse(temp[1]);
                        result.AddRange(range(a, b).AsEnumerable());
                    }
                }
    
                return result;
            }
        }
