    class A
    {
        public void Fun()
        {
            Console.Write("Class A!");
            FunProtected();
        }
    
        protected virtual void FunProtected()
        {
        }
    }
    
    class B : A
    {
        protected override void FunProtected()
        {
            Console.Write("Class B!");
        }
    }
