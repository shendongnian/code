    ilgen.Emit(OpCodes.Ldfld, counterFieldInfo); <=== should be ldsfld, by the way
    ilgen.Emit(OpCodes.Ldc_I4, 1); // stack is now [counter] [1]
    ilgen.Emit(OpCodes.Add); // stack is now [counter + 1]
    ilgen.Emit(OpCodes.Pop); // stack is now empty
    ilgen.Emit(OpCodes.Ret); // return
