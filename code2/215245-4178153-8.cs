    public class StructWrapper<T> : AnInterface where T : struct
    {   
        private readonly Action action;
        
        // deliberately exposed
        public T UnderlyingStruct { get; private set; }
   
        public StructWrapper(T underlyingStruct)
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
