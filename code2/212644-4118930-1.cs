    class A
    {
        public virtual void Fun()
        {
            Console.Write("Class A!");
        }
    }
    
    class B : A
    {
        public override void Fun()
        {
            // call the base method which will print Class A!
            base.Fun(); 
            Console.Write("Class B!");
        }
    }
