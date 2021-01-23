    private static void Main(string[] args)
    {
        List<string> inputValues = new List<string>
        {
            @"http://www.ibm.com/test",
            "hello/test",
            "//",
            "SomethingElseWithoutDelimiter",
            null,
            "     ", //spaces
        };
        foreach (var str in inputValues)
        {
            Console.WriteLine("\"{0}\" ==> \"{1}\"", str, str.RemoveTextAfterLastChar('/'));
        }
    }
