    Type t = typeof (Foo);
    var theMethods = t.GetMethods().Where(mi =>
                                {
                                    var p = mi.GetParameters();
                                    if (p.Length != 2)
                                        return false;
    
                                    if (p[0].ParameterType != typeof(int) 
                                         || p[1].ParameterType != typeof(string))
                                        return false;
    
                                    return mi.ReturnType == typeof (void);
                                });
