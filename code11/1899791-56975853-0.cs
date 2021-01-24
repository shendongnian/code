    class Program
    {
        static void Main(string[] args)
        {
            //string MyName = "Hello";
            NameHolder MyName = new NameHolder();
            MyName.Name = "hello";
            Console.WriteLine($"Main thinks Main's name is: {MyName.Name}");
            Console.WriteLine($"");
            Console.WriteLine($"Creating ClassA");
            ClassA classA = new ClassA(MyName);
            Console.WriteLine($"Main thinks Main's name is: {MyName.Name}");
            classA.WriteOutMainName();
            MyName.Name = "GoodBye";
            Console.WriteLine($"");
            Console.WriteLine($"Main changed it's name to: {MyName.Name}");
            Console.WriteLine($"");
            Console.WriteLine($"Main thinks Main's name is: {MyName.Name}");
            classA.WriteOutMainName();
        }
    }
    public class ClassA
    {
        NameHolder MainName;
        public ClassA(NameHolder mainName)
        {
            MainName = mainName;
        }
        public void WriteOutMainName()
        {
            Console.WriteLine($"ClassA thinks Main's name is: {MainName.Name}");
        }
    }
    public class NameHolder
    {
        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
