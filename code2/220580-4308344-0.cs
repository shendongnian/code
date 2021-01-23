        static void Main(string[] args)
        {
            Assembly[] assemblies = new Assembly[] { 
                typeof(string).Assembly,
                typeof(Uri).Assembly, 
                typeof(System.Linq.Enumerable).Assembly};
            List<string> final = new List<string>();
            Debug.WriteLine("Checked assemblies: ");
            foreach (Assembly assembly in assemblies)
            {
                Debug.WriteLine(assembly.FullName);
                Type[] types = assembly.GetTypes();
                IEnumerable<Type> genericTypes = types.Where(t => t.IsGenericType && t.IsPublic);
                foreach (Type t in genericTypes)
                {
                    final.Add(t.FullName);
                }
            }
            final.Sort();
            Debug.WriteLine("Generic classes: ");
            foreach (string s in final)
            {
                Debug.WriteLine(s);
            }
        }
