    static void Main()
    {
        var array = new[] { 3, 2, 1 };
    
        var result = array.OrderBy(SimpleSort);
    
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    
    public static T SimpleSort<T>(T t)
    {
        return t;
    }
