        internal class ClassInfo
    {
        public ClassInfo(string namespaceName, string className)
        {
            NamespaceName = namespaceName;
            ClassName = className;
        }
        public string NamespaceName { get; private set; }
        public string ClassName { get; private set; }
    }
    class Program
    {
        static void Main(string[] args) 
        {
            IList<ClassInfo> _classes = new List<ClassInfo>();
            //DirectoryInfo folder = new DirectoryInfo(Directory.GetCurrentDirectory());
            DirectoryInfo folder = new DirectoryInfo(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0");
            ProcessFolder(folder, _classes);
            Console.WriteLine();
            Console.WriteLine("*************** NAMESPACES ***************");
            Console.WriteLine();
            PrintNamespaces(_classes);
            Console.WriteLine();
            Console.WriteLine("*************** NAMESPACES/CLASSES ***************");
            Console.WriteLine();
            PrintClassesByNamespaces(_classes);
        }
        private static void PrintNamespaces(IList<ClassInfo> classes)
        {
            var namespaces = (from c in classes
                              orderby c.NamespaceName
                              select c.NamespaceName).Distinct();
            foreach (string s in namespaces)
            {
                Console.WriteLine(s);
            }
        }
        private static void PrintClassesByNamespaces(IList<ClassInfo> classes)
        {
            var namespaces = (from c in classes
                              orderby c.NamespaceName
                              select c.NamespaceName).Distinct();
            foreach (string s in namespaces)
            {
                Console.WriteLine(s);
                var namespaceClasses = (from c in classes
                                        where c.NamespaceName == s
                                        orderby c.ClassName
                                        select c.ClassName).Distinct();
                foreach (string className in namespaceClasses)
                {
                    Console.WriteLine($"   {className}");
                }
            }
        }
        public static void ProcessFolder(DirectoryInfo directory, IList<ClassInfo> classes)
        {
            Console.WriteLine($"folder: {directory.FullName}");
            
            foreach (FileInfo f in directory.GetFiles("*.dll"))
            {
                ProcessAssembly(directory, f.FullName, classes);
            }
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                ProcessFolder(d, classes);
            }
        }
        private static void ProcessAssembly(DirectoryInfo directory, string fileName, IList<ClassInfo> classes)
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFile(fileName);
                foreach (var t in assembly.DefinedTypes)
                {
                    classes.Add(new ClassInfo(t.Namespace, t.Name));
                    Console.WriteLine($"{t.Namespace} - {t.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something wrong loading {fileName} - {ex.Message}");
            }
        }        
    }
