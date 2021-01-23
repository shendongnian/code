    public class Program
    {
	    public static void Main()
	    {		
		    IEnumerable<MyClass> myClassItems = new List<MyClass>() {new MyClass("1"), new MyClass("2"), new MyClass("InvalidValue"), new MyClass("3")};
		
		    foreach (int integer in myClassItems.SelectTry<MyClass, string, int>(x => x.MyIntegerAsString, int.TryParse))
		    {
			    Console.WriteLine(integer);
		    }
	    }
    }
    public static class LinqUtilities
    {
	    public delegate bool TryFunc<in TSource, TResult>(TSource arg, out TResult result);
	    public static IEnumerable<TResult> SelectTry<TSource, TValue, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, TValue> selector, 
            TryFunc<TValue, TResult> executor)
        {
            foreach (TSource s in source)
            {
                TResult r;
                if (executor(selector(s), out r))
                    yield return r;
            }
        }
    }
    public class MyClass
    {
	    public MyClass(string integerAsString)
	    {
		    this.MyIntegerAsString = integerAsString;
	    }
	     public string MyIntegerAsString{get;set;}
    }
