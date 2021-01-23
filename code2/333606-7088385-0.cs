        BindingSource bs = (BindingSource)listBox1.DataSource;
        OrderedDictionary ord = (OrderedDictionary)bs.DataSource;
        Dictionary<string, string> dict = new Dictionary<string, string>();
        
        foreach (DictionaryEntry item in ord)
            dict.Add(item.Key.ToString(), item.Value.ToString());
