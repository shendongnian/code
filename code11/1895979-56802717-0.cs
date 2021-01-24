csharp
    public class MyClass
    {
        public int Id { get; set; }
        public int Id2 { get; set; }
        public object[] GetPKs() => new object[] { Id, Id2 };
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            foreach (var item in myClass.GetType().GetProperties())
            {
                Console.WriteLine(item.Name);
            }
            Console.Read();
        }
    }
