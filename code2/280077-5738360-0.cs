    public class SomeObject
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public SomeObject() { ID = 1; Name = "test"; }
    }
    
    static void Main(string[] args)
    {
        SomeObject obj1 = new SomeObject();
        GetObject(obj1, 2);
    
        Console.WriteLine(obj1.ID); // prints 1
        Console.Read();
    }
    
    public static void GetObject(SomeObject obj1, int id)
    {
        var obj = new SomeObject();
        obj.ID = id;
        obj.Name = "";
    
        obj1 = obj;
    }
