    public class Impl<T> : AnInterface where T : struct
    {   
        private readonly Action action;
        
        public T UnderlyingStruct { get; private set; }
   
        public Impl(T underlyingStruct )
        {
            UnderlyingStruct = underlyingStruct;
            action = (Action)Delegate.CreateDelegate
                      (typeof(Action), underlyingStruct, "DoSomething");
        }
    
        public void DoSomething()
        {
            action();
        }
    }
 
