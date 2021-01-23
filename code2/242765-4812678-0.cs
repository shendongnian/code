    public class Thing
    {
        public string Property {get;set;}
    }
    public static void Go(Thing thing)
    {
        thing = new Thing();
        thing.Property = "Changed";
    }
    public static void Go(ref Thing thing)
    {
        thing = new Thing();
        thing.Property = "Changed";
    }
