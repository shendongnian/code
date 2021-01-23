    public class SomeType
    {
        public IEnumerable<bool> Collection { get; set; }
    }
    static void Main()
    {
        var list = new SomeType
        {
            Collection = new List<bool> { true, true, true }
        };
        var functor = Compiler((SomeType t) => t.Collection, (bool x) => x);
    }
    static MethodInfo FindMethod<TInput>(Type location, string name)
    {
        var handle = location
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(method => method.Name == name).First();
        return handle.MakeGenericMethod(typeof(TInput));
    }
    static Predicate<TObject> Compiler<TObject, TProperty>(
        Expression<Func<TObject, IEnumerable<TProperty>>> selector,
        Expression<Func<TProperty, bool>> predicate)
    {
        var query = FindMethod<TProperty>(typeof(Enumerable), "All");
        var param1 = Expression.Parameter(typeof(TObject));
        var expression = Expression.Call(query,
            new Expression[] { Expression.Invoke(selector, param1), predicate });
        return Expression.Lambda<Predicate<TObject>>(expression, param1).Compile();
    }
