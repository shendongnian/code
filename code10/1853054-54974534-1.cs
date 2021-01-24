    class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var builder = new ContainerBuilder();
    
                builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).As<IGenerator>();
                builder.RegisterType<MyFacade>();
    
                var container = builder.Build();
    
                using (var scope = container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<MyFacade>();
    
                    service.MyParser("foo");
                    service.MyParser("bar");
                    service.MyParser("foobar");
                }
            }
        }
    
        public class MyFacade
        {
            private readonly IEnumerable<IGenerator> _generators;
    
            public MyFacade(IEnumerable<IGenerator> generators)
            {
                _generators = generators;
            }
    
            public IGenerator MyParser(string extension)
            {
                foreach (var generator in _generators)
                {
                    if (generator.Accept(extension))
                    {
                        return generator;
                    }
                }
    
                throw new NotFoundException($"Generator for {extension} doesnt exist.");
            }
        }
    
        public interface IGenerator
        {
            bool Accept(string extension);
        }
    
        public class CppTopicGenerator : IGenerator
        {
            public bool Accept(string extension)
            {
                Console.WriteLine("CppTopicGenerator checking executed");
                return extension == "foo";
            }
        }
    
        public class PhpTopicGenerator : IGenerator
        {
            public bool Accept(string extension)
            {
                Console.WriteLine("PhpTopicGenerator checking executed");
                return extension == "bar";
            }
        }
    
        public class JavaTopicGenerator : IGenerator
        {
            public bool Accept(string extension)
            {
                Console.WriteLine("JavaTopicGenerator checking executed");
                return extension == "foobar";
            }
        }
