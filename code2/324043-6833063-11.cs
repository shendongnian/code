    public static T With<T>(this T obj, params Action<T>[] assignments)
        where T : ICloneable {
        if (obj == null)
            throw new ArgumentNullException("obj");
        if (assignments == null)
            throw new ArgumentNullException("assignments");
        var copy = (T)obj.Clone();
        foreach (var a in assignments) {
            a(copy);
        }
        return copy;
    }
    public static void Test() {
        var foo = new Foo { Id = 1, Bar = "blah" };
        var newFoo = foo.With(x => x.Id = 2, x => x.Bar = "boo-ya");
        Console.WriteLine(newFoo.Bar);
    }
