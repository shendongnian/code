    public static IEnumerable<T> SearchCallTree<T>(this TypeDefinition startingClass,
                                                   Func<MethodReference, bool> methodSelect,
                                                   Func<Instruction, Stack<MethodReference>, T> resultFunc,
                                                   int maxdepth)
        where T : class
    {
        return new CallTreeSearch<T>(startingClass.Methods.Cast<MethodDefinition>(), methodSelect, resultFunc, maxdepth);
    }
    public static IEnumerable<T> SearchCallTree<T>(this MethodDefinition startingMethod,
                                                   Func<MethodReference, bool> methodSelect,
                                                   Func<Instruction, Stack<MethodReference>, T> resultFunc,
                                                   int maxdepth)
        where T : class
    {
        return new CallTreeSearch<T>(new[] { startingMethod }, methodSelect, resultFunc, maxdepth); 
    }
    // Actual usage:
    private static IEnumerable<TypeUsage> SearchMessages(TypeDefinition uiType, bool onlyConstructions)
    {
        return uiType.SearchCallTree(IsBusinessCall,
               (instruction, stack) => DetectRequestUsage(instruction, stack, onlyConstructions));
    }
