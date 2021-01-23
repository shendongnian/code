    class Program
    {
        static void Main(string[] args)
        {
            string json = new JavaScriptSerializer().Serialize(new { Bar = "foo" });
            Console.WriteLine(json);
        }
    }
