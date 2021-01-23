        public static List<string> FileGrep(string filePath, string searchText)
        {
            var matches = new List<string>();
            using (var f = File.OpenRead(filePath))
            {
                var s = new StreamReader(f);
                while (!s.EndOfStream)
                {
                    var line = s.ReadLine();
                    if (line != null && line.Contains(searchText)) matches.Add(line);   
                }
                f.Close();
            }
            return matches;
        }
