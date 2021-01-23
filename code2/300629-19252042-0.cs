    foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies()) 
                {                    
                    if (assemblyName.ToString().Contains("PresentationFramework"))
                    {
                        Assembly assembly = Assembly.Load(assemblyName);
                        Common.AddToLog(assembly.FullName);
                        Type[] allTypes = assembly.GetTypes();
                        foreach (Type type in allTypes)
                        {
                            if (type.IsSubclassOf(typeof(DependencyObject)))
                            {
                                allControlTypes.Add(type);
                            }
                        }
                    }
                }
