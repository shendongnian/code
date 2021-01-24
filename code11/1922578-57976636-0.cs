       class Program
        {
            static void Main(string[] args)
            {
                Bar b = new Bar();
                Console.WriteLine(b.ClassName());
    
            }
        }
    
        abstract class Foo
        {
            public string ClassName()
            {
                return GetType().Name;
            }
        }
    
        class Bar : Foo
        {
    
        }
