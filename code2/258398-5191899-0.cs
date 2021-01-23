        static void PreloadAssemblies()
        {
            int count = -1;
            Debug.WriteLine("Loading assemblies...");
            List<string> done = new List<string>(); // important...
            Queue<AssemblyName> queue = new Queue<AssemblyName>();
            queue.Enqueue(Assembly.GetEntryAssembly().GetName());
            while (queue.Count > 0)
            {
                AssemblyName an = queue.Dequeue();
                if (done.Contains(an.FullName)) continue;
                done.Add(an.FullName);
                try
                {
                    Assembly loaded = Assembly.Load(an);
                    count++;
                    foreach (AssemblyName next in loaded.GetReferencedAssemblies())
                    {
                        queue.Enqueue(next);
                    }
                }
                catch { } // not a problem
            }
            Debug.WriteLine("Assemblies loaded: " + count);
        }
