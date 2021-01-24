	private static List<IMyString> GetMyStrings(string key, List<IMyString> input)
    {
        return input.WithId(key).ToList();
    }
    public static void Main()
    {
        var foo = new List<IMyString>{ new MyString { Id = "yes"}, new MyString { Id = "no" } };
        var result = GetMyStrings("yes", foo);
        var result2 = foo.WithId("no");
        Console.WriteLine(result2);
    }
