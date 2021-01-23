    public static class StackManager
    {
        private static Stack ParameterStack;
        
        static StackManager()
        {
            ParameterStack = Stack.Synchronized(new Stack());
        }
    
        public static T Pop<T>()
        {
            object RawObject;
            T Result = default(T);
    
            RawObject = ParameterStack.Pop();
    
            if (RawObject != null && RawObject is T)
                Result = RawObject;
    
            return Result;
        }
    
        public static void Push<T>(T Data)
        {
    
                ParameterStack.Push(Data);
    
        }
    }
