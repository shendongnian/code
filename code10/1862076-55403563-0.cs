            var content = "zf3kabxcde224lkzf3mabxc51+crsdtzf3nab=";
            var patternLength = 3;            
            var patterns = new HashSet<string>();
            for (int i = 0; i < content.Length - patternLength + 1; i++)
            {
                var pattern = content.Substring(i, patternLength);                
                var Occurrence = Regex.Matches(content, pattern.Replace("+", @"\+")).Count;
                if (Occurrence > 1 && !patterns.Contains(pattern))
                {
                    Console.WriteLine(pattern + " : " + Occurrence);
                    patterns.Add(pattern);
                }
            }
