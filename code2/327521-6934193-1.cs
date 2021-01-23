    public interface ISomeInterface
    {
       void f1();
       int f2(string p1);
       ...
    }
    public class FuncImplementation : ISomeInterface
    {
       public Action Func_f1 { get; set; }
       public Func<string,int> Func_f2 { get; set; }
       ...
       void f1() { Func_f1(); }
       int f2(string p1) { return Func_f2(p1); }
       ...
    }
