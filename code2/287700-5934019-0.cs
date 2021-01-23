            var processingModules = from mod in
                                       AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly =>
                                       {
                                           return from t in assembly.GetTypes()
                                                  where 
                                                        t.GetInterfaces().Contains(typeof(IProcessingModule<T>))
                                                        && t.GetConstructor(Type.EmptyTypes) != null
                                                        && t.GetCustomAttributes(typeof(ProcessModuleAttribute), true)
                                                               .Cast<ProcessModuleAttribute>()
                                                               .Select(e => e.Processes.Contains(manager.Name))
                                                               .Contains(true)
                                                        
                                                  select Activator.CreateInstance(t) as IProcessingModule<T>;
                                       })
                                       orderby mod.ModuleOrder
                                           select mod;
