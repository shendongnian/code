    class Program
    {
        static void Main(string[] args)
        {
            var d = GetUserDynamic();
            Console.WriteLine("{0}.{1}", d.FirstName, d.LastName);
        }
        private static dynamic GetUserDynamic()
        {
            dynamic d = new ExpandoObject();
            d.FirstName = "amandeep";
            d.LastName = "tur";
            return d;
        }
    }
