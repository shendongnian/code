    using System.Runtime.CompilerServices;
    
    //...
    
    bool IsCompilerGenerated(Type t)
    {
    	var attr = Attribute.GetCustomAttribute(t, typeof(CompilerGeneratedAttribute));
    	return attr != null;
    }
