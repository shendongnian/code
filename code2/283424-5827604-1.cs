        List<string> namespaces = new List<string>();
        var refs = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
        foreach (var rf in refs) {
            if (rf.Name == "System.Core")
            {
                var ass = Assembly.Load(rf);
                foreach (var tp in ass.GetTypes())
                {
                    if (!namespaces.Contains(tp.Namespace))
                    {
                        namespaces.Add(tp.Namespace);
                        Console.WriteLine(tp.Namespace);
                    }
                }
            }
        }
