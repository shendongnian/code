    Type yourType = typeof(List<string>);  // for example
    using (var provider = new CSharpCodeProvider())
    {
        var typeRef = new CodeTypeReference(yourType);
        Console.WriteLine(provider.GetTypeOutput(typeRef));
    }
