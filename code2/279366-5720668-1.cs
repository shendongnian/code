    public static List<string> GetName()
    {
        List<string> aString = new List<string>();
        aString .Add("cat");
        aString .Add("apple");
        aString .Add("bass");
        aString .Add("dog");
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
