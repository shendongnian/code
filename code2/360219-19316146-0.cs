    public class ClassTag<V> where V : class { }
    public class StructTag<V> where V : struct { }
    public void Func<V>(V v, ClassTag<V> dummy = null) where V : class
    {
        Console.Writeln("class");
    }
    public void Func<V>(V v, StructTag<V> dummy = null) where V : struct
    {
        Console.Writeln("struct");
    }
    public void Func<V>(V? v, StructTag<V> dummy = null) where V : struct
    {
        Console.Writeln("struct?");
    }
    static void Main()
    {
        Func("A");
        Func(5);
        Func((int?)5);
    }
