    public class Program
    {
        public static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            string name = "name";
            name += obj.Text = name;
            Console.Write(name); //prints namename
        }
    }
