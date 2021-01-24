        static void Main(string[] args)
        {
            var rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var dlls = Directory.GetFiles(rootPath, "*.dll", SearchOption.AllDirectories).Where(row => row.Contains("\\bin\\")).Distinct();
            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFrom(dll);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var members = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static);
                    foreach (MemberInfo member in members)
                    {
                        Console.WriteLine($"{assembly.GetName().Name}.{type.Name}.{member.Name}");
                    }
                    var members2 = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Static);
                    foreach (MemberInfo member in members2)
                    {
                        Console.WriteLine($"{assembly.GetName().Name}.{type.Name}.{member.Name}");
                    }
                }
            }
        }
