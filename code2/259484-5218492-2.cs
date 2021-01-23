    var myMethod = myInstance.GetType()
                             .GetMethods()
                             .Where(m => m.Name == "MyMethod")
                             .Select(m => new {
                                                  Method = m,
                                                  Params = m.GetParameters(),
                                                  Args = m.GetGenericArguments()
                                              })
                             .Where(x => x.Params.Length == 1
                                         && x.Args.Length == 1
                                         && x.Params[0].ParameterType == x.Args[0])
                             .Select(x => x.Method)
                             .First();
