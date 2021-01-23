    public class TestClass
    {
        public string Property1 { get; set; }
        private string Property2 { get; set; }
        public string Property9 { get; set; }
        private string Property10 { get; set; }
        protected internal string Property3 { get; set; }
        protected string Property4 { get; set; }
        internal string Property5 { get; set; }
        protected internal int Property6 { get; set; }
        protected int Property7 { get; set; }
        internal int Property8 { get; set; }
        internal static void ShowPropertyAccessScope(Type t)
        {
            foreach (var prop in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                Console.WriteLine("{0,-28} {1,15}", "Public property:", prop.Name);
            }
            var nonPublic = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var prop in nonPublic.Where(p => p.GetGetMethod(true)?.IsAssembly == true))
            {
                Console.WriteLine("{0,-28} {1,15}", "Internal property:", prop.Name);
            }
            foreach (var prop in nonPublic.Where(p => p.GetGetMethod(true)?.IsFamilyOrAssembly == true))
            {
                Console.WriteLine("{0,-28} {1,15}", "Internal protected property:", prop.Name);
            }
            foreach (var prop in nonPublic.Where(p => p.GetGetMethod(true)?.IsFamily == true))
            {
                Console.WriteLine("{0,-28} {1,15}", "Protected property:", prop.Name);
            }
            foreach (var prop in nonPublic.Where(p => p.GetGetMethod(true)?.IsPrivate == true))
            {
                Console.WriteLine("{0,-28} {1,15}", "Private property:", prop.Name);
            }
        }
        static void Main() 
        {
            ShowPropertyAccessScope(typeof(TestClass));
        }
    }
