    private delegate int AddDelegate(int a, int b);
    public static void DynamicMethodTest()
    {
        // Create a DynamicMethod that adds its two int parameters
        // Passing "true" as the final (restrictedSkipVisibility) parameter causes the method to be JITted immediately when you call .CreateDelegate()
        var dynamicAdd = new DynamicMethod("Add", typeof(int), new[] { typeof(int), typeof(int) }, true);
        var il = dynamicAdd.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Add);
        il.Emit(OpCodes.Ret);
        // Use the non-generic AddDelegate defined above, rather than a generic one like Func<int, int, int> so that Marshal.GetFunctionPointerForDelegate() works
        var addDelegate = (AddDelegate)dynamicAdd.CreateDelegate(typeof(AddDelegate));
        Console.WriteLine("Function Pointer: 0x{0:x16}", Marshal.GetFunctionPointerForDelegate(addDelegate).ToInt64());
        Debugger.Break();
    }
