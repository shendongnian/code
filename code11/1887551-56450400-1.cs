    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        private void Run()
        {
            MyClass myClass = new MyClass();
            KeepingItDRY(myClass, "SomeName", "Name");
            System.Console.WriteLine(myClass.Name);
        }
        private void KeepingItDRY<T>(T target, object value, string property) =>
            typeof(T).GetProperty(property).SetValue(target, value);
    }
    public class MyClass
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int SomethingElse { get; set; }
    }
