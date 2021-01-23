    void Main()
    {
        var types = new []{typeof(string), typeof(Guid)};
        SomeOtherObject model = new SomeOtherObject();
    	foreach(var t in types)
        {
            var mapped = typeof(AutoMapping<>).MakeGenericType(t);
        
            var p = Expression.Parameter(mapped, "m");
            var expression = Expression.Lambda(
                                 Expression.GetActionType(mapped),
                                 Expression.Call(p, mapped.GetMethod("Do"),
                                 Expression.Constant("Something")), p);
        
            typeof(SomeOtherObject).GetMethod("TheMethod")
                                   .MakeGenericMethod(t)
                                   .Invoke(model,
                                           new object[] { expression.Compile() });
        }
    }
    
    class AutoMapping<T>
    {
        public void Do(string p)
        {
            Console.WriteLine(typeof(T).ToString());
            Console.WriteLine(p);
        }
    }
    
    class SomeOtherObject
    {
        public void TheMethod<T>(Action<AutoMapping<T>> action)
        {
            var x = new AutoMapping<T>();
            action(x);
        }
    }
