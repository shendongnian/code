    // From type.
    var typeDoc = DocsService.GetXmlFromType(typeof(Stub));
    
    // From property.
    var propertyInfo = typeof(Stub).GetProperty("PropertyWithDoc");
    var propertyDoc = DocsService.GetXmlFromMember(propertyInfo);
    
    // From method.
    var methodInfo = typeof(Stub).GetMethod("MethodWithGenericParameter");
    var methodDoc = DocsService.GetXmlFromMember(methodInfo);
    
    // From assembly.
    var assemblyDoc = DocsService.GetXmlFromAssembly(typeof(Stub).Assembly);
