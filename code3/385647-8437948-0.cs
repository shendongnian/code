            static void Main(string[] args)
            {
                string text1 = "3Z10Z";
                string text2 = "3Z 10Z";
                string pattern = @"(\d[A-Z])\s*(.*)";
    
                Match match = Regex.Match(text1, pattern);
                if (match.Success)
                {
                    Console.WriteLine("prefix {0} suffix {1}.", 
                      match.Groups[1].Value, match.Groups[2].Value);
                }
    
                match = Regex.Match(text2, pattern);
                if (match.Success)
                {
                    Console.WriteLine("prefix {0} suffix {1}.", 
                  match.Groups[1].Value, match.Groups[2].Value);
                }
    
                Console.ReadLine();
            }
