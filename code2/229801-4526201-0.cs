    using Mono.Cecil;
    using Mono.Cecil.Cil;
    
    // ...
    
    static void SearchMethod (MethodDefinition method)
    {    
        foreach (var instruction in method.Body.Instructions) {
            if (instruction.OpCode != OpCodes.Newobj)
                continue;
    
            var constructor = (MethodReference) instruction.Operand;
            if (constructor.DeclaringType.FullName != "Foo.Bar.Baz")
                continue;
            Console.WriteLine ("new Foo.Bar.Baz in {0}", method.FullName);
        }
    }
    
    static void Main ()
    {
        var module = ModuleDefinition.ReadModule ("Foo.Bar.dll");
        var methods = module.Types.SelectMany (t => t.Methods).Where (m => m.HasBody);
        foreach (var method in methods)
             SearchMethod (method);
    }
