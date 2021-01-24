    #IF !DEBUG
    using MySpecialStuff 
    #endif
    
    public class MyClass
    {
        static void Main()
        {
    #IF !DEBUG
            var msc = new MySpecialClass(); 
    #endif
        }   
    }
