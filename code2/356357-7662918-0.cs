    List<string> list = new List<string>();
            foreach (string line in File.ReadAllLines(somefile.txt))
            {
                if (!list.Contains(line))
                {
                    list.Add(line);
                }
            }
