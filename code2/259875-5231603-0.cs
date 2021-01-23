    class Program
    {
        private int i;
        public void method1()
        {            
            Program p = new Program();
            p.i = 5;        // OK when accessed within the class
        }
    }
