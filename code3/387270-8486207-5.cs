        var method = new DynamicMethod("MulBy4", typeof (int),
             new Type[] {typeof (int)});
        var il = method.GetILGenerator();
        var multiplier = il.DeclareLocal(typeof (int));
        var result = il.DeclareLocal(typeof(int));
        il.Emit(OpCodes.Ldc_I4_4);
        il.Emit(OpCodes.Stloc, multiplier);
        il.Emit(OpCodes.Ldloc, multiplier);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Mul);
        il.Emit(OpCodes.Stloc, result);
        il.Emit(OpCodes.Ldloc, result);
        il.Emit(OpCodes.Ret);
        var mulBy4= (Func<int,int>)method.CreateDelegate(typeof (Func<int, int>));
        var twelve = mulBy4(3);
