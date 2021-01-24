    private static void DisplayGenericMethodInfo(MethodInfo mi)
        {
            Console.WriteLine("\r\n{0}", mi);
    
            Console.WriteLine("\tIs this a generic method definition? {0}", 
                mi.IsGenericMethodDefinition);
    
            Console.WriteLine("\tIs it a generic method? {0}", 
                mi.IsGenericMethod);
    
            Console.WriteLine("\tDoes it have unassigned generic parameters? {0}", 
                mi.ContainsGenericParameters);
    
            // If this is a generic method, display its type arguments.
            //
            if (mi.IsGenericMethod)
            {
                Type[] typeArguments = mi.GetGenericArguments();
    
                Console.WriteLine("\tList type arguments ({0}):", 
                    typeArguments.Length);
    
                foreach (Type tParam in typeArguments)
                {
                    // IsGenericParameter is true only for generic type
                    // parameters.
                    //
                    if (tParam.IsGenericParameter)
                    {
                        Console.WriteLine("\t\t{0}  parameter position {1}" +
                            "\n\t\t   declaring method: {2}",
                            tParam,
                            tParam.GenericParameterPosition,
                            tParam.DeclaringMethod);
                    }
                    else
                    {
                        Console.WriteLine("\t\t{0}", tParam);
                    }
                }
            }
        }
