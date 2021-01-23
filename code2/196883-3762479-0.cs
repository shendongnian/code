    public class Program
    {
        class Foo
        {
            public string Bar { get; private set; }
        }
    
        static void Main(string[] args)
        {
            var prop = typeof(Foo).GetProperty("Bar");
            if (prop != null)
            {
                // The property exists
                var setter = prop.GetSetMethod(true);
                if (setter != null)
                {
                    // There's a setter
                    Console.WriteLine(setter.IsPublic);
                }
            }
        }
    }
