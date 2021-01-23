    public class FList<T> : List<T>
    {
        public FList<T> Do(string method, params object[] args)
        {
            var methodInfo = GetType().GetMethod(method);
            
            if (methodInfo == null)
                throw new InvalidOperationException("I have no " + method + " method.");
            
            if (methodInfo.ReturnType != typeof(void))
                throw new InvalidOperationException("I'm only meant for void methods.");
            methodInfo.Invoke(this, args);
            return this;
        }
    }
    {
        var list = new FList<string>();
    
        list.Do("Add", "foo")
            .Do("Add", "remove me")
            .Do("Add", "bar")
            .Do("RemoveAt", 1)
            .Do("Insert", 1, "replacement");
    
        foreach (var item in list)
            Console.WriteLine(item);    
    }
