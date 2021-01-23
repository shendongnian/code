        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        foreach(string recordline in tags) 
        {
           string recordstag = recordline.Split('\t')[1].Trim();
           int value;
           if (!dictionary.TryGetValue(recordstag, out value))
             dictionary.Add(recordstag, 1);
           else
             dictionary[recordstag] = value + 1;
        }
