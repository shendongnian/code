    static void Main(string[] args)
    {
        string[] removeTheseWords = { "aaa", "bbb", "ccc" };
    
        string contents = File.ReadAllText("C://Users//Pete//Desktop//testdata.csv");
        string output = string.Empty;
    
        foreach (string value in removeTheseWords)
        {
            output = contents.Replace(value, string.Empty);
        }
    }
