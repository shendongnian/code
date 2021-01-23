    class Test
    {
        
        protected void foo(int len, ref classA obj){}
        protected void foo(int len, ref classB obj){  }
        protected void foo(int len, ref classC obj){}
        static readonly Dictionary<Type, Delegate> functions;
        delegate void MyDelegate<T>(Test arg0, int len, ref T obj);
        static Test()
        {
            functions = new Dictionary<Type, Delegate>();
            foreach (var method in typeof(Test).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (method.Name != "foo") continue;
                var args = method.GetParameters();
                if (args.Length != 2 || args[0].ParameterType != typeof(int)) continue;
                var type = args[1].ParameterType.GetElementType();
                functions[type] = Delegate.CreateDelegate(
                    typeof(MyDelegate<>).MakeGenericType(type), method);
            }
        }
        public T callFoo<T>(int len)
            where T : new()  //ensure an empty constructor so it can be activated
        {
            T obj = new T();
            Delegate function;
            if (!functions.TryGetValue(typeof(T), out function)) throw new NotSupportedException(
                 "foo is not supported for " + typeof(T).Name);
            ((MyDelegate<T>)function)(this, len, ref obj);
            return obj;
        }
    }
