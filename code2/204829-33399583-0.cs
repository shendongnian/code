    public static void Main()
    {
        foreach (object item in GetList())
        {
            var x = Cast(item, new { ContactID = 0, FullName = "" });
            Console.WriteLine(x.ContactID + " " + x.FullName);
        }
    }
    public static IEnumerable<object> GetList()
    {
        yield return new { ContactID = 4, FullName = "Jack Smith" };
        yield return new { ContactID = 5, FullName = "John Doe" };
    }
    public static T Cast<T>(object obj, T type)
    {
        return (T)obj;
    }
