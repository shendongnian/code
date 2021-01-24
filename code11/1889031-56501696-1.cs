    public static void Method<T>(T item)
    {
       Console.WriteLine(item);
    }
    
    static void Main(string[] args)
    {
       var list = new List<int>()
                     {
                        1,
                        2,
                        3,
                        4,
                        5,
                        6
                     };
    
       list.CallForEach(x => x.MethodEx());
       // or you could use a method group, its its not an extension method
       list.CallForEach(Method);
    
       // ForEach is already part of the List class
       list.ForEach(x => x.MethodEx());
       list.ForEach(Method);
    }
