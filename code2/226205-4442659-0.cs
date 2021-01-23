    public class VarClass
    {
        public int publicID = 10;
        private int privateID = 100;
        public VarClass()
        {
            Console.WriteLine(publicID);
            Console.WriteLine(privateID);
        }
        public class InnerClass
        {
            public InnerClass()
            {
                VarClass c = new VarClass();
                Console.WriteLine(c.privateID);
                Console.WriteLine(c.publicID);
            }
        }
    }
    public class OuterClass
    {
        public OuterClass()
        {
            VarClass c = new VarClass();
            Console.WriteLine(c.privateID); // Compile Error
            Console.WriteLine(c.publicID);
        }
    }
