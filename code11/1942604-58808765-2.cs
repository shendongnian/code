    void Main()
    {
        var a = new Example();
        Example b = null;
        
        Console.WriteLine(!a); // False
        Console.WriteLine(!b); // True
    }
    
    public class Example {
        public static bool operator !(Example example) {return example == null;}
        public static bool operator true(Example example) => example != null;
        public static bool operator false(Example example) => example == null;
    }
