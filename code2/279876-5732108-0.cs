    class Program
    {
        static void Main(string[] args)
        {
            MyAwesomeClass original = new MyAwesomeClass { Name = "Bob" };
            MyLessAwesomeClass casted = original;
            Console.WriteLine(casted.Name);
        }
    }
    public class MyAwesomeClass
    {
        public static implicit operator MyLessAwesomeClass(MyAwesomeClass original)
        {
            return new MyLessAwesomeClass() { Name = original.Name };
        }
        public string Name
        {
            get;
            set;
        }
    }
    public class MyLessAwesomeClass
    {
        public string Name
        {
            get;
            set;
        }
    }
