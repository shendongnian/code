    using CodeDom;
    // ...
    Type t = typeof(bool);
    var typeRef = new CodeTypeReference(t);
    var provider = new CSharpCodeProvider();
    string typeName = provider.GetTypeOutput(typeRef);
