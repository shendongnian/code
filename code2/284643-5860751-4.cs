    class Program
        {
            public static void GetEntities<T>() where T : class
            {
                           
                var info = typeof(TestClass1).GetProperties().Where(p => p.PropertyType == typeof(List<T>));
                
                Console.WriteLine(info.FirstOrDefault().Name);
            }
    
            static void Main(string[] args)
            {
                GetEntities<int>();
                Console.ReadLine();
            }
        }
        public class TestClass1
        {
            public List<int> IntTest { get; set; }
            public List<double> DoubleTest { get; set; }
            public List<string> IStringTest { get; set; }
        }
