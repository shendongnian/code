    class Program
    {
        static void Main(string[] args)
        {
            Person sergio = new Person();
            sergio.Items.Add("test", "test");
    
            Console.ReadKey();
        }
    
        public class Person
        {
            public Dictionary<string, string> Items { get; set; }
    
            public Person()
            {
                Items = new Dictionary<string, string>();
            }
        }
    }
