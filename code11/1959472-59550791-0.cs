    public class Type1
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    public class Type2
    {
        public string Property1 { get; set; }
        public string Property3 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Type1 { Property1 = "Banana" };
            var t2 = new Type2();
            var properties1 = typeof(Type1).GetProperties().ToList();
            var properties2 = typeof(Type2).GetProperties().ToList();
            foreach(var p in properties1)
            {
                var found = properties2.FirstOrDefault(i => i.Name == p.Name);
                if(found != null)
                {
                    found.SetValue(t2, p.GetValue(t1));
                }
            }
            Console.WriteLine(t2.Property1);
        }
    }
