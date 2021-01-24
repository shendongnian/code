    public class MyClass
    {
        static void Main()
        {
    #IF !DEBUG
            var msc = new MySpecialStuff.MySpecialClass(); 
    #endif
        }   
    }
