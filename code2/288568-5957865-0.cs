        Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
        using (StreamReader reader = new StreamReader("filename"))
        {
            string token = null;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("["))
                    d[token] = new List<string>();
                else
                    d[token].Add(line);
            }
        }
