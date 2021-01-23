    static void Main(string[] args)
    {
        var module = ModuleDefinition.ReadModule("CecilTest.exe");
        var type = module.Types.First(x => x.Name == "A");
        var method = type.Methods.First(x => x.Name == "test");
        PrintMethods(method);
        PrintFields(method);
        Console.ReadLine();
    }
    public static void PrintMethods(MethodDefinition method)
    {
        Console.WriteLine(method.Name);
        foreach (var instruction in method.Body.Instructions)
        {
            if (instruction.OpCode == OpCodes.Call)
            {
                MethodReference methodCall = instruction.Operand as MethodReference;
                if(methodCall != null)
                    Console.WriteLine("\t" + methodCall.Name);
            }
        }
    }
    public static void PrintFields(MethodDefinition method)
    {
        Console.WriteLine(method.Name);
        foreach (var instruction in method.Body.Instructions)
        {
            if (instruction.OpCode == OpCodes.Ldfld)
            {
                FieldReference field = instruction.Operand as FieldReference;
                if (field != null)
                    Console.WriteLine("\t" + field.Name);
            }
        }
    }
