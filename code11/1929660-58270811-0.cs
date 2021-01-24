          public override Type BindToType(string assemblyName, string typeName)
            {
                Type tyType = null;
                string sShortAssemblyName = assemblyName.Split(',')[0];
                System.Reflection.Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                string typeSearchString;
                try
                {
                    typeSearchString = typeName.Split('+')[1];
                    foreach (System.Reflection.Assembly ayAssembly in ayAssemblies)
                    {
                        foreach (Type type in ayAssembly.GetTypes())
                        {
                            if (type.FullName.Contains(typeSearchString))
                            {
                                tyType = ayAssembly.GetType(type.FullName);
                                return tyType;
                            }
                        }
                    }
                }
                catch
                {
                    foreach (System.Reflection.Assembly ayAssembly in ayAssemblies)
                    {
                        if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
                        {
                            tyType = ayAssembly.GetType(typeName);
                            return tyType;
                        }
                    }
                }
                return tyType;
            }
