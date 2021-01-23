    static List<Type> numerics = new List<Type>();
    
    static void Main(string[] args)
    {
        numerics.Add(typeof(Decimal));
        numerics.Add(typeof(Double));
        numerics.Add(typeof(Int16));
        numerics.Add(typeof(Int32));
        numerics.Add(typeof(Int64));
        numerics.Add(typeof(Single));
        numerics.Add(typeof(UInt16));
        numerics.Add(typeof(UInt32));
        numerics.Add(typeof(UInt64));
    
        Console.WriteLine("StringNumber 55:  {0} {1}", typeof(int), GetItemIdFromUrl<int>("55"));
        Console.WriteLine("StringNumber 5B99:  {0} {1}", typeof(int), GetItemIdFromUrl<int>("5B99"));
    
        Console.ReadKey();
    }
    
    public static T GetItemIdFromUrl<T>(string stringNumber)
    {
        try
        {
            if (numerics.Contains(typeof(T)))
                return (T)Convert.ChangeType(stringNumber, typeof(T));
            else
                return default(T);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine("Exception\r\n{0}", argEx);
            return default(T);
        }
        catch (FormatException formatEx)
        {
            Console.WriteLine("Exception\r\n{0}", formatEx);
            return default(T);
        }
    }
