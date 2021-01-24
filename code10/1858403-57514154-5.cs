    internal static class InstructionExtensions
    {
        public static bool IsCall(this Instruction instruction)
        {
            var code = instruction.OpCode.Code;
            return code == Code.Call ||
                   code == Code.Callvirt;
        }
        public static bool IsBoxing(this Instruction instruction) =>
            instruction.OpCode.Code == Code.Box;
        public static bool IsLoadArg(this Instruction instruction)
        {
            var code = instruction.OpCode.Code;
            return code == Code.Ldarg_0 ||
                   code == Code.Ldarg_1 ||
                   code == Code.Ldarg_2 ||
                   code == Code.Ldarg_3 ||
                   code == Code.Ldarg_S;
        }
        public static bool IsLoadLoc(this Instruction instruction)
        {
            var code = instruction.OpCode.Code;
            return code == Code.Ldloc_0 ||
                   code == Code.Ldloc_1 ||
                   code == Code.Ldloc_2 ||
                   code == Code.Ldloc_3 ||
                   code == Code.Ldloc_S;
        }
        public static bool IsLoadField(this Instruction instruction)
        {
            var code = instruction.OpCode.Code;
            return code == Code.Ldfld ||
                   code == Code.Ldsfld;
        }
        public static int GetArgIndex(this Instruction instruction, bool isInstance)
        {
            if (instruction.OpCode.Code == Code.Ldarg_S)
                return ((ParameterDefinition)instruction.Operand).Index;
            var index = -1;
            var code = instruction.OpCode.Code;
            if (code == Code.Ldarg_0)
                index = 0;
            else if (code == Code.Ldarg_1)
                index = 1;
            else if (code == Code.Ldarg_2)
                index = 2;
            else if (code == Code.Ldarg_3)
                index = 3;
            if (index != -1 && isInstance)
                index--;
            return index;
        }
        public static int GetLocIndex(this Instruction instruction)
        {
            if (instruction.OpCode.Code == Code.Ldloc_S)
                return ((VariableDefinition)instruction.Operand).Index;
            var code = instruction.OpCode.Code;
            if (code == Code.Ldloc_0)
               return 0;
            if (code == Code.Ldloc_1)
                return 1;
            if (code == Code.Ldloc_2)
                return 2;
            if (code == Code.Ldloc_3)
                return 3;
            return -1;
        }
        public static bool IsLoad(this Instruction instruction) =>
            instruction.IsLoadArg() ||
            instruction.IsLoadLoc() ||
            instruction.IsLoadField();
    }
