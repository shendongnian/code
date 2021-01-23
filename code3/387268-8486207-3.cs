        var method = new DynamicMethod("MulBy4", typeof (int),
             new Type[] {typeof (int)});
        var il = method.GetILGenerator();
        il.Emit(OpCodes.Ldc_I4_4);
        il.Emit(OpCodes.Stloc_0); // this usage is 
        il.Emit(OpCodes.Ldloc_0); // deliberately silly
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Mul);
        il.Emit(OpCodes.Stloc_1); // this usage is 
        il.Emit(OpCodes.Ldloc_1); // deliberately silly
        il.Emit(OpCodes.Ret);
        var mulBy4= (Func<int,int>)method.CreateDelegate(typeof (Func<int, int>));
        var twelve = mulBy4(3);
