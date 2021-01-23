    class B : A
    {
        public B() { }
    
        public override void Test()
        {
            Console.WriteLine("I am B!");
            base.Test();
        }
    
        protected void TestFromA()
        {
            base.Test()
        }
    }
