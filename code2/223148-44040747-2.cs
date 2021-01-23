    Type type = /* Get a type reference somehow */
    if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
    {
        return compiler.GetTypeOutput(new CodeTypeReference(type.GetGenericArguments()[0])).Replace("System.","") + "?";
    }
    else
    {
        return compiler.GetTypeOutput(new CodeTypeReference(type)).Replace("System.","");
    }   
 
