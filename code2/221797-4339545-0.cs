    static void Main()
    {        
        var dic = new Dictionary<string, Func<string>>();
        dic.Add("A", () => "Hello World");  // Constant lambda
        dic.Add("B", ConstructString);      // Calculated
        dic.Add("C", delegate { return string.Empty; });    // Anonymous delegate
    }
    static string ConstructString()
    {
        return DateTime.Now.ToString();
    }
