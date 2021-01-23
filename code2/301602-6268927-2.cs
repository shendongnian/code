    public interface ToType<R>
    {
        R ToType();
    }
    public class B
    {
        public int x; 
    }
    public class A : ToType<B>
    {
        string x = "5";
        public B ToType()
        {
            B aB = new B();
            aB.x = int.Parse(x);
            return aB;
        }
    }
    public static IEnumerable<Ret> Fn<Ret,Parm>(IList<Parm> P)  where Parm : ToType<Ret>
    {
        var Results = new List<Ret>();
        foreach(Parm p in P)
        {
            Results.Add(p.ToType());
        }
        return Results;
    }
    static void Main(string[] args)
    {
        List<A> inLst = new List<A>() { new A()};
        var lst = Fn<B, A>(inLst);
    }
