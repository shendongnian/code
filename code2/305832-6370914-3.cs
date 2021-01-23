            ilgen.Emit(OpCodes.Ldsfld, counterFieldInfo);
            ilgen.Emit(OpCodes.Ldc_I4, 1);
            ilgen.Emit(OpCodes.Add);
            ilgen.Emit(OpCodes.Stsfld, counterFieldInfo);
            ilgen.Emit(OpCodes.Ret);
