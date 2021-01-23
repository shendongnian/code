    static void Main(string[] args)
    {
        var s = "4,6,8\\n9,4";
        foreach (var a in s.Split(new string[] { ",", "\\n" }, StringSplitOptions.RemoveEmptyEntries))
            System.Diagnostics.Debug.WriteLine(a);
    }
