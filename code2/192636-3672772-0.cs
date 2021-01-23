    // In factory assembly:
    public class Factory
    {
        public Factory()
        {
            token = new object();
            MyClass.StoreCreateToken(token);
        }
        
        public MyClass Create()
        {
            return new MyClass(token);
        }
        
        private object token;
    }
    // In other assembly:
    public class MyClass
    {
        public static void StoreCreateToken(object token)
        {
            if (token != null) throw new InvalidOperationException(
                "Only one factory can create MyClass.");
                
            this.token = token;
        }
        
        public MyClass(object token)
        {
            if (this.token != token) throw new InvalidOperationException(
                "Need an appropriate token to create MyClass.");
        }
        
        private static object token;
    }
