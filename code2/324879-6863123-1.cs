    class FunctionRepository : List<Delegate> // could also be a Dictionary<,>
    {
        public R Invoke<R>(string name, params object[] args)
        {
            var _delegate = this.Single(x => x.Method.ReturnType == typeof(R)
                && x.Method.Name == name);
            return (R)_delegate.DynamicInvoke(args);
        }  
        public Func<R> LookUp<R>(string name, params object[] args)
        { 
            var _delegate = this.Single(x => x.Method.ReturnType == typeof(R) 
                && x.Method.Name == name);
            return () => (R)_delegate.DynamicInvoke(args); 
        }
        
        public Func<Object[], R> LookUp<R>(string name)
        { 
            var _delegate = this.Single(x => x.Method.ReturnType == typeof(R) 
                && x.Method.Name == name);
            return (args) => (R)_delegate.DynamicInvoke(args); 
        }
    }
