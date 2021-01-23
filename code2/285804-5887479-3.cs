    class Program
    {
        static void Main(string[] args)
        {
            string name = "Matt";
            var prop = new DelegateProperty<string>(
                () => name,
                value => name = value);
            var test = new Test(prop);
            Console.WriteLine(test.Name);
            test.Name = "Ben";
            Console.WriteLine(name);
            Console.ReadKey();
        }
    }
    public class Test
    {
        private readonly DelegateProperty<string> NameProperty;
        public Test(DelegateProperty<string> prop)
        {
            NameProperty = prop;   
        }
        public string Name
        {
            get { return NameProperty; }
            set { NameProperty.Value = value; }
        }
    }
