        private static Dictionary<string, Type> types;
        private static readonly object GeneralLock = new object();
        public static Type FindType(string typeName)
        {
            if (types == null)
            {
                lock (GeneralLock)
                {
                    if (types == null)
                    {
                        types = new Dictionary<string, Type>();
                        var appAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                        foreach (var appAssembly in appAssemblies)
                        {
                            foreach (var type in appAssembly.GetTypes())
                                if (!types.ContainsKey(type.Name))
                                    types.Add(type.Name, type);
                        }
                    }
                }
            }
            return types[typeName];
        }
