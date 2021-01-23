    public class X
    {
        public static String y = "abc";
    }
    
    // other code, even without instances of X alive:
    Console.WriteLine(X.y);
