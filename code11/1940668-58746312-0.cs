    public static ReadOnlySpan<char> ToSpan(int src)
            {
                int len = GetLength(src);
                Span<char> chars = new char[len];
                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i]= (char)((Math.Floor(src / Math.Pow(10, (chars.Length - i - 1))) % 10) + 48);
                }
                return chars;
    
                static int GetLength(int src)
                {
                    int len = 0;
                    while (src > 0)
                    {
                        src = src / 10;
                        len++;
                    }
                    return len;
                }
                
            }
            static void Main(string[] args)
            {
                int x = 3334;
                var data = ToSpan(x);
                var copy= int.Parse(data);
                Console.WriteLine(copy);
            }
