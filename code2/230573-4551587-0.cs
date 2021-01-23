    MethodInfo methodInfo = typeof(Class)
                                .GetMethods(
                                    BindingFlags.Public | BindingFlags.Static
                                )
                                .Where(m => m.Name == "StaticMethod")
                                .Where(m => m.IsGenericMethod)
                                .Where(m => m.GetGenericArguments().Length == 1)
                                .Where(m => m.GetParameters().Length == 3)
                                .Where(m =>
                                    m.GetParameters()[0].ParameterType == 
                                        m.GetGenericArguments()[0] &&
                                    m.GetParameters()[1].ParameterType == 
                                        typeof(IInterface1) &&
                                    m.GetParameters()[2].ParameterType == 
                                        typeof(IEnumerable<IInterface2>)
                                )
                                .Single();
