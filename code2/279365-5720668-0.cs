    public static List<string> GetName()
    {
        List<string> aString = new List<string>();
        localList.Add("cat");
        localList.Add("apple");
        localList.Add("bass");
        localList.Add("dog");
      return aString;
    }
    public static List<string> DeleteName()
    {
        List<string>  aString = GetName();
        foreach (string x in aString)
        {
            Console.WriteLine(x);
        }
        return aString;
    }
