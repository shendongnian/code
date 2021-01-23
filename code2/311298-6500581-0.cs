    public class X { }
    public class Y { }
    public class Z { }
    static void Main(string[] args)
    {
        var l1 = new List<X> { new X() };
        var l2 = new List<Y> { new Y() };
        var l3 = new List<Z> { new Z() };
        var master = new List<dynamic>();
        master.AddRange(l1);
        master.AddRange(l2);
        master.AddRange(l3);
        Parallel.ForEach(master,
            val =>
            {
                var isX = val is X;
            });
    }
