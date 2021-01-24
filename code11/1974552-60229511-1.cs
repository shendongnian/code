csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        List<BaseClass> items = new List<BaseClass>();
        items.Add(new BaseChild<int>());
        items.Add(new BaseChild<bool>());
        items.Add(new BaseChild<double>());
        for (int i = 0; i <= items.Count; i++)
        {
            var generated = Convert(items[i]);
            //Do something
        }
    }
    static object Convert(BaseClass item)
    {
        var type = item.GetType().GenericTypeArguments[0];
        var method = typeof(Program).GetMethod("GenericConvert", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(type);
        return method.Invoke(null, new[] { item });
    }
    static GenClass<T> GenericConvert<T>(BaseChild<T> from)
    {
        return new GenClass<T> { assignHere = from.data };
    }
}
