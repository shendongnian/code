                Type concreteType = null;
                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in loadedAssemblies)
                {
                    concreteType = assembly.GetType(concreteTypeValue.AttemptedValue);
                    if (null != concreteType)
                    {
                        break;
                    }
                }
