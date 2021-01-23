    public IntermediateClass<T> Init<T>()
    {
        ValidateUsage(Assembly.GetCallingAssembly());
        return new IntermediateClass<T>();
    }
    void ValidateUsage(Assembly assembly)
    {
        // 1) Use Mono.Cecil to inspect the codebase inside the assembly
        var assemblyLocation = assembly.CodeBase.Replace("file:///", "");
        var monoCecilAssembly = AssemblyFactory.GetAssembly(assemblyLocation);
        // 2) Retrieve the list of Instructions in the calling method
        var methods = monoCecilAssembly.Modules...Types...Methods...Instructions
        // (It's a little more complicated than that...
        //  if anybody would like more specific information on how I got this,
        //  let me know... I just didn't want to clutter up this post)
        // 3) Those instructions refer to OpCodes and Operands....
        //    Defining "invalid method" as a method that calls "Init" but not "Save"
        var methodCallingInit = method.Body.Instructions.Any
            (instruction => instruction.OpCode.Name.Equals("callvirt")
                         && instruction.Operand is IMethodReference
                         && instruction.Operand.ToString.Equals(INITMETHODSIGNATURE);
        var methodNotCallingSave = !method.Body.Instructions.Any
            (instruction => instruction.OpCode.Name.Equals("callvirt")
                         && instruction.Operand is IMethodReference
                         && instruction.Operand.ToString.Equals(SAVEMETHODSIGNATURE);
        var methodInvalid = methodCallingInit && methodNotCallingSave;
        // Note: this is partially pseudocode;
        // It doesn't 100% faithfully represent either Mono.Cecil's syntax or my own
        // There are actually a lot of annoying casts involved, omitted for sanity
        // 4) Obviously, if the method is invalid, throw
        if (methodInvalid)
        {
            throw new Exception(String.Format("Bad developer! BAD! {0}", method.Name));
        }
    }
