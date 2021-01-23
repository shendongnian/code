    public class Foo
    {
        private readonly ExpandoObject _dict = new ExpandoObject();
  
        public dynamic Data
        {
            get { return _dict; }
        }
        public Foo(params object[] args)
        {
             foreach (var arg in args)
                 _dict.Add(arg.ToString(), "..");
        }
    }
    var foo = new Foo("a", "b", "c");
    foo.Data.x = 3.14;
    Console.Write(foo.Data.a);
