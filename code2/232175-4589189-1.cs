        static Dictionary<String, Assembly> _assemblies = new Dictionary<String, Assembly>(StringComparer.OrdinalIgnoreCase);
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                Assembly dll;
                var name = new AssemblyName(args.Name).Name + ".dll";
                if(!_assemblies.TryGetValue(name, out dll))
                {
                    Assembly res = typeof(THIS_CLASS).Assembly;
                    using (var input = res.GetManifestResourceStream(name))
                    {
                        if (input == null)
                        {
                            LogWrite("Assembly {0} does not contain {1}", res, name);
                            return null;
                        }
                        if (null == (dll = Assembly.Load(input.ToArray(), AppDomain.CurrentDomain.Evidence)))
                        {
                            LogWrite("Assembly {0} failed to load.", name);
                            return null;
                        }
                        LogWrite("Loaded assembly {0}.", name);
                        _assemblies[name] = dll;
                        return dll;
                    }
                }
                return dll;
            };
