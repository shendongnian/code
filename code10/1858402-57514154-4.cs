    private static ResolvedArgument GetPassedValue(StackFrame frame, MethodDefinition method, ParameterDefinition parameter)
    {
        var info = frame.GetMethod();
        var caller = info.GetMethodDefinition();
        var instruction = caller.GetInstruction(frame.GetILOffset());
        while (instruction != null)
        {
            if (instruction.IsCall() &&
                instruction.Operand is MethodDefinition md &&
                md.FullName.Equals(method.FullName))
                    break;
            instruction = instruction.Previous;
        }
        if (instruction == null)
            throw new Exception("Not supposed to get here.");
        var il = caller
            .Body
            .Instructions
            .TakeWhile(i => i.Offset != instruction.Offset)
            .Reverse()
            .Where(i => !i.IsBoxing() && (caller.IsStatic || i.OpCode.Code != Code.Ldarg_0))
            .TakeWhile(i =>i.IsLoad())
            .Reverse()
            .ToList();
        if (il.Count != method.Parameters.Count)
            throw new NotSupportedException("Possible attempt to pass an expression");
        instruction = il[parameter.Index];
        var name = "<failed to resolve>";
        if (instruction.IsLoadArg())
        {
            var index = instruction.GetArgIndex(!caller.IsStatic);
            name = caller.Parameters.Single(p => p.Index == index).Name;
        }
        if (instruction.IsLoadField())
            name = ((FieldDefinition)instruction.Operand).Name;
        if (instruction.IsLoadLoc())
        {
            var index = instruction.GetLocIndex();
            var locals = new MonoCecilReader().Read(info);
            name = locals.Single(loc => loc.Index == index).Name;
        }
        return new ResolvedArgument(name, parameter.Name);
    }
