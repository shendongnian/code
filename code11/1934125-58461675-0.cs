    class Program
    {
        static void Main(string[] args)
        {
            string keyword = "m";
            using (TestingEntities1 db = new TestingEntities1())
            {
                var models = db.Teachers.Where(a => a.Name.Replace("a", " ").Contains(keyword));
                foreach (var item in models)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
