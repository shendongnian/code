    using System.CodeDom;
    using System.CodeDom.Compiler;
    
    CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
    var typeRef = new CodeTypeReference("System.Nullable`1[System.Int32]");
    string typeOutput = provider.GetTypeOutput(typeRef); // "System.Nullable<int>"
