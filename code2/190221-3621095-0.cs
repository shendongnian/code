    var cs = new CSharpCodeProvider();
    var vb = new VBCodeProvider();
    var type = typeof (int);
    Console.WriteLine("Type Name: {0}", type.Name); // Int32
    Console.WriteLine("C# Type Name: {0}", cs.GetTypeOutput(new CodeTypeReference(type))); // int
    Console.WriteLine("VB Type Name: {0}", vb.GetTypeOutput(new CodeTypeReference(type))); // Integer
