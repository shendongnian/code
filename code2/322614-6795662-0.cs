    public delegate ICollection<string> FooDelegate(string a, out int b);
    public class Foo
    {
        public void DoFoo()
        {
           int x;
           var coll = TheFunc("bar", out x);
        }
    
        public FooDelegate TheFunc { get; set; }
    }
