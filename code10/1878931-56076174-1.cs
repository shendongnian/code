            Dictionary<string, string> dict = new Dictionary<string, string>();
    //----------
            string value = "test";
            string key = "some key";
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                if(value == string.Empty)
                {
                    dict.Remove(key);
                }
                else
                {
                    dict.Add(key, value);
                }
            }
