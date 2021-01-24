     void RegisterAllIncludedInterfaces(string assemblyName, string @namespace)
        {
            System.Reflection.Assembly
                .Load(assemblyName)
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.Namespace == @namespace))
                .ToList()
                .ForEach(t =>
                {
                    For(t.GetInterfaces().Single(i => i.Namespace == @namespace))
                   .HybridHttpOrThreadLocalScoped()
                   .Use(t);
                });
        }
