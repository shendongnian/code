    public class FooAttribute : Attribute
    {
        public string Description { get; set; }
    }
    
    public class Bar
    {
        [Foo(Description = "Some description")]
        public string BarProperty { get; set; }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            var foos = (FooAttribute[])typeof(Bar)
                .GetProperty("BarProperty")
                .GetCustomAttributes(typeof(FooAttribute), true);
            Console.WriteLine(foos[0].Description);
        }
    }
