    class Program
    {
        static void Main(string[] args)
        {
            var lTest = new List<Test>();
            var s = lTest.DefaultIfEmpty(new Test() { i = 1, name = "testing" }).First().name;
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
    public class Test
    {
        public int i { get; set; }
        public string name { get; set; }
    }
