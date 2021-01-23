    class MyClass
    {
        static MyClass()
        {
           if (!ValidateLicenceKey())
           {
               throw new Exception("Invalid License");
           }
        }
    }
