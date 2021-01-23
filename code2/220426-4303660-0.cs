    string[] data = new string[] { "1B", "2C", "01", "11", "3F", "5F", "02",      "01",   "06", "12", "1C" };
        
            string splitStr = "01";
            List<string> result = new List<string>();
            foreach (var v in string.Join(string.Empty, data)
                              .Split(new string []{splitStr},StringSplitOptions.None)
                              .Skip(1))
            {
                        result.Add(splitStr + v);
            }
