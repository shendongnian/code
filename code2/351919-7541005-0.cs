    public static class ObjectExtensions
    {
        public static string TypeFullName(this object obj)
        {
            return obj.GetType().FullName;
        }
    }
    static void Main(string[] args)
    {
        var obj = new object();
        Console.WriteLine(obj.TypeFullName());
        var s = "test";
        Console.WriteLine(s.TypeFullName());
    }
