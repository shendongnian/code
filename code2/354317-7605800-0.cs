    static void Main(string[] args)
    {
        var s = "4,6,8\n9,4";
        foreach (var a in s.Split(new char[] { ',', '\n' }))
            System.Diagnostics.Debug.WriteLine(a);
    }
