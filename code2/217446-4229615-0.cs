    class MyException : Exception {
      public MyException(int p1) {}
    }
    
    var ctor = typeof(MyException).GetConstructor(new Type[] {typeof(int)});
    var gen = builder.GetILGenerator();
    gen.Emit(OpCodes.Ldc_I4, 42);
    gen.Emit(OpCodes.NewObj, ctor);
    gen.Emit(OpCodes.Throw);
