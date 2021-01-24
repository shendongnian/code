    public static class Program
    {
            private static void Main(string[] args)
            {
                
                string input = @"
                blue widgets
    
                widgets for cars
    
                big widgets for real men";
    
                string pattern = @"(?!widgets\b)\b\w+";
    
                string res = Regex.Replace(input, pattern, (match) =>
                {
                    return $"<b>{match}</b>";
                });
    
                Console.WriteLine(res);
            }
        }
    }
