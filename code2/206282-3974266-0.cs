    public static Dictionary<T,U> Edit<T,U>(this Dictionary<T,U> dictionary1, Dictionary<T,U> dictionary2) {
        foreach (T key in dictionary2.Keys)
        {
            if (dictionary1.ContainsKey(key))
            {
                dictionary1[key] = dictionary2[key];
            }
        }
        return dictionary1;
    }
