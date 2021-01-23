    List<string> namespaces = new List<string>();
                
            var m = MethodInfo.GetCurrentMethod();
                foreach (var mb in m.DeclaringType.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
                {
                    if (mb.MemberType == MemberTypes.Method && ((MethodBase)mb).GetMethodBody() != null)
                    {
    
                        foreach (var p in ((MethodInfo)mb).GetMethodBody().LocalVariables)
                        {
                            if (!namespaces.Contains(p.LocalType.Namespace))
                            {
                                namespaces.Add(p.LocalType.Namespace);
                                Console.WriteLine(p.LocalType.Namespace);
                            }
                        }
                    }
                    else if (mb.MemberType == MemberTypes.Field) {
                        string ns = ((System.Reflection.FieldInfo)mb).FieldType.Namespace;
                        if (!namespaces.Contains(ns))
                        {                        
                            namespaces.Add(ns);
                            Console.WriteLine(ns);
                        }
                    }
                }
