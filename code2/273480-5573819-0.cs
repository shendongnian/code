        var dictionary = new Dictionary<string, MyType>();
        foreach (var item in myCollection)
        {
            string key = item.Key;
            if (dictionary.ContainsKey(key))
            {
                // Handle error
                Debug.Fail(string.Format("Found duplicate key: {0}", key));
            }
            else
            {
                dictionary.Add(key, item);
            }
        }
