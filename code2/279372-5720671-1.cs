    public static List<string> GetName(List<string> aString)
    {
        List<string> localList= new List<string>(aString);
        localList.Add("cat");
        localList.Add("apple");
        localList.Add("bass");
        localList.Add("dog");
        return localList;
    }
    public static List<string> DeleteName(List<string> aString)
    {
        aString = GetName(aString);
        foreach (string x in aString)
        {
            Console.WriteLine(x);
        }
        return aString;
    }
