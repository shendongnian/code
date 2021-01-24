    public static void ReadFile()
        {
            List<string> lines = new List<string>();
            using (var sr = new System.IO.StreamReader(@"C:\test\tempfile.txt"))
            {
                string line = null;
                while((line = sr.ReadLine()) != null)
                {
                    lines.Insert(0, line);
                }
                lines.RemoveRange(0, 20);
            }
            List<string> result = lines.Where((x, i) => i % 2 == 0).ToList();
          //Results:
          // Fourth-Read:2019/09/24, 12345, abcdefg
          // Third-Read:2019/09/24, 12345, abcdefg
          // Second-Read:2019/09/24, 12345, abcdefg
          // First-Read:2019/09/24, 12345, abcdefg
        }
