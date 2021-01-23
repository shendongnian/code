    private static int ComputeNumberOfAnonymousTypes(Assembly assembly)
    {
        return (from type in assembly.GetTypes()
                where Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute))
                        && type.Name.StartsWith("<>f__AnonymousType")
                select type)
            .Count();
    }
