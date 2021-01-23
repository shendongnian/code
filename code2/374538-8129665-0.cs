    static void Main()
    {
        var obj = new Foo();
        var bw = new BinaryWriter(Stream.Null);
        FieldInfo fi = typeof(Foo).GetField("FooBar");
        var call = Expression.Call(Expression.Constant(bw), "Write", null, Expression.Constant(fi.GetValue(obj)));
        var lambda = Expression.Lambda<Action>(call).Compile();
        lambda();
    }
    public class Foo
    {
        public int FooBar = 12;
    }
