    public class SomeType
    {
        public string var1;
        public string var2;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<SomeType>();
            myList.Add(new SomeType() { var1 = "abc", var2 = "abc" });
            myList.Add(new SomeType() { var1 = "def", var2 = "def" });
            foreach (var item in myList.AsQueryable().Where("var1=\"abc\""))
                Console.WriteLine("item.var1 = " + item.var1);
        }
    }
