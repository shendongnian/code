    public abstract class BaseClass
    {
        public abstract void BeforeMe();
    
        public abstract void AfterMe();
    
        public virtual void DoMe()
        {
           Console.WriteLine("Executing DoMe of BaseClass");
        }
        
        public void ExecuteMe()
        {
            BeforeMe();
            DoMe();
            AfterMe();
        }
    }
