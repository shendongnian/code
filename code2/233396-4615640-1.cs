    using CodeDom;
    using Microsoft.CSharp;
    // ...
    Type t = typeof(bool);
    string typeName;
    using (var provider = new CSharpCodeProvider())
    {
        var typeRef = new CodeTypeReference(t);
        typeName = provider.GetTypeOutput(typeRef);
    }
    Console.WriteLine(typeName);    // bool
