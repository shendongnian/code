            Assembly asm = typeof(MyApplication).Assembly;
            List<string> namespaces = new List<string>();
            foreach (var type in asm.GetTypes())
            {
                string ns = type.Namespace;
                if (!namespaces.Contains(ns))
                {
                    namespaces.Add(ns);
                }
            }
            foreach (var ns in namespaces)
            {
                Console.WriteLine(ns);
            }
