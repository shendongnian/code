    private PropertyInfo GetImplementedProperty(PropertyInfo pi)
        {
            var type = pi.DeclaringType;
            var interfaces = type.GetInterfaces();
            for(int interfaceIndex = 0; interfaceIndex < interfaces.Length; interfaceIndex++)
            {
                var iface = interfaces[interfaceIndex];
                var interfaceMethods = type.GetInterfaceMap(iface).TargetMethods;
                MethodInfo matchingMethod = null;
                for (int x = 0; x < interfaceMethods.Length; x++)
                {
                    if (pi.GetGetMethod().LooseCompare(interfaceMethods[x]) || pi.GetSetMethod().LooseCompare(interfaceMethods[x]))
                    {
                        matchingMethod = type.GetInterfaceMap(iface).InterfaceMethods[x];
                        break; 
                    }
                }
                if (matchingMethod == null) continue;
                var interfacePi = from i in interfaces
                                  from property in i.GetProperties()
                                  where property.GetGetMethod().LooseCompare(matchingMethod) || property.GetSetMethod().LooseCompare(matchingMethod)
                                  select property;
                return interfacePi.First();
            }
            
            return pi;
        } 
