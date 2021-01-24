            var all = new HashSet<Dictionary<string, string>>();
            Dictionary<string, string> newDict = new Dictionary<string, string>();
            newDict.Add("M", "T");
            all.Add(newDict);
            foreach(Dictionary<string,string> dict in all)
            {
                foreach(KeyValuePair<string,string> pair in dict)
                {
                    string key = pair.Key;
                    string value = pair.Value;
                }
            }
