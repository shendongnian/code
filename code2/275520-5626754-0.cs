    void Main()
    {
     string s1 = "foo";
     string s2 = null;
     Console.WriteLine(s1.Coalesce("none"));
     Console.WriteLine(s2.Coalesce("none"));
     var coalescer = new Coalescer<string>("none");
     Console.WriteLine(coalescer.Coalesce(s1));
     Console.WriteLine(coalescer.Coalesce(s2));
    }
    public class Coalescer<T>
    {
     	T _def;
     	public Coalescer(T def) { _def = def; }
    	public T Coalesce(T s) { return s == null ? _def : s; }
    }
    public static class CoalesceExtension
    {
    	public static string Coalesce(this string s, string def) { return s ?? def; }
    }
