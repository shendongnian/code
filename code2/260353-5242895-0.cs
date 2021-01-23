    interface IFoo
    {
        void DoIt();
    }
    
    class NullFoo : IFoo
    {
        public void DoIt()
        {
          // do nothing
        }
    }
    
    class TraceFoo : IFoo
    {
        public void DoIt()
        {
            Console.WriteLine("Did it.");
        }
    }
