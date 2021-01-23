    for (int i = 0; i < MyDic.Count; i++)
    {
        KeyValuePair<string, string> s = MyDic.ElementAt(i);
        MyDic.Remove(s.Key);
        MyDic.Add(s.Key, "NewValue");
    }
