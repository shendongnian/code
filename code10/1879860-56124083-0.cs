    static void Main(string[] args)
    {
        var method = new DynamicMethod("Get17HashCode", typeof(int), new Type[0], typeof(Program).Module);
        var ilGenerator = method.GetILGenerator();
        ilGenerator.DeclareLocal(typeof(int));
        ilGenerator.Emit(OpCodes.Ldc_I4_S, 17);
        ilGenerator.Emit(OpCodes.Stloc_0);
        ilGenerator.Emit(OpCodes.Ldloca_S, 0);
        ilGenerator.Emit(OpCodes.Call, typeof(int).GetMethod(nameof(int.GetHashCode)));
        ilGenerator.Emit(OpCodes.Ret);
        var delegateFunction = (Func<int>)method.CreateDelegate(typeof(Func<int>));
        var result = delegateFunction();
        Console.WriteLine($"Got {result}");
    }
