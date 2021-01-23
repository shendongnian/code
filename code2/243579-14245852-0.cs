        private string[] splitQuoted(string line, char delimeter)
        {
            string[] array;
            List<string> list = new List<string>();
            do
            {
                if (line.StartsWith("\""))
                {
                    line = line.Substring(1);
                    int idx = line.IndexOf("\"");
                    while (line.IndexOf("\"", idx) == line.IndexOf("\"\"", idx))
                    {
                        idx = line.IndexOf("\"\"", idx) + 2;
                    }
                    idx = line.IndexOf("\"", idx);
                    list.Add(line.Substring(0, idx));
                    line = line.Substring(idx + 2);
                }
                else
                {
                    list.Add(line.Substring(0, Math.Max(line.IndexOf(delimeter), 0)));
                    line = line.Substring(line.IndexOf(delimeter) + 1);
                }
            }
            while (line.IndexOf(delimeter) != -1);
            list.Add(line);
            array = new string[list.Count];
            list.CopyTo(array);
            return array;
        }
