    class MyClass
    {
        static int instances = 0;
    
        public MyClass()
        {
            instances++;
        }
        ~MyClass()
        {
            instances--;
        }
    }
