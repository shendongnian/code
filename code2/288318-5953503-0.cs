                container.Register
                (
                    AllTypes.FromThisAssembly()
                    .Where(c=> c.GetInterface(typeof(LifestyleUponInterface.InterfaceForSingleton).Name)!=null )
                    .Configure( c=> c.LifeStyle.Singleton )
                );
                container.Register
                (
                    AllTypes.FromThisAssembly()
                    .Where(c => c.GetInterface(typeof(LifestyleUponInterface.InterfaceForTransient).Name) != null)
                    //.If(Component.IsInNamespace("<yourNamespace>"))
                    .Configure(c => c.LifeStyle.Transient)
                );
