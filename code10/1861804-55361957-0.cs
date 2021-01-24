    Dictionary<string, int> CopyDict(Dictionar<string, int> dic)
    {
        Dictionar<string, int> tmp = new Dictionar<string, int>();
        foreach(var item in dic)
        {
            tmp.add(item.key, item.value);
        }
        return tmp;
    }
    //In your code add the dictionary
    DICT2.ADD(t, CopyDict(DICT1));
