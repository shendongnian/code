    using System.Reflection;
    
    public bool IsCompilerGenerated(Type type)
    {
        return type.GetCustomAttribute<System.Runtime.CompilerServices.CompilerGeneratedAttribute>() != null;
    }
