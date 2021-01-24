    protected override bool Execute(Assignment assignment, ILValue<T> output)
    {
    var a = assignment.GetInput(A).ToLValue();
    var b = assignment.GetInput(B).ToLValue();
    
    var aRows = a.Layout.Shape[0];
    var aCols = a.Layout.Shape[1];
    var bRows = b.Layout.Shape[0];
    var bCols = b.Layout.Shape[1];
    
    if (assignment.Context.Type == ContextType.Gpu
    && Alea.cuBLAS.Blas.IsAvailable
    && a.Layout.IsFullyPacked
    && b.Layout.IsFullyPacked
    && output.Layout.IsInnerChangeMostFullyPacked)
    {
    
    var context = assignment.Context.ToGpuContext();
    var blas = context.Blas;
    
    var aPtr = a.Buffer.Ptr;
    var bPtr = b.Buffer.Ptr;
    var cPtr = output.Buffer.Ptr;
    
    var m = (int)bCols;
    var n = (int)aRows;
    var k = (int)aCols;
    var lda = a.Layout.IsInnerChangeMost ? aCols : aRows;
    var ldb = b.Layout.IsInnerChangeMost ? bCols : bRows;
    var ldc = output.Layout.Shape[1];
    
    var opa = a.Layout.IsInnerChangeMost ? Alea.cuBLAS.Operation.N : Alea.cuBLAS.Operation.T;
    var opb = b.Layout.IsInnerChangeMost ? Alea.cuBLAS.Operation.N : Alea.cuBLAS.Operation.T;
    
    if (typeof(T) == typeof(double))
    {
    blas.Gemm(opb, opa, m, n, k, 1.0, bPtr.Reinterpret<double>(), (int)ldb, aPtr.Reinterpret<double>(), (int)lda,
    0.0, cPtr.Reinterpret<double>(), (int)ldc);
    return true;
    }
    
    if (typeof(T) == typeof(float))
    {
    blas.Gemm(opb, opa, m, n, k, 1.0f, bPtr.Reinterpret<float>(), (int)ldb, aPtr.Reinterpret<float>(), (int)lda,
    0.0f, cPtr.Reinterpret<float>(), (int)ldc);
    return true;
    }
    }
    
    var readA = a.Buffer.GetReader2();
    var readB = b.Buffer.GetReader2();
    var writeC = output.Buffer.Writer2;
    var zero = Zero;
    var add = Add;
    var mul = Mul;
    
    //if (assignment.AttentionState.Type == ContextType.Gpu)
    //{
    //    Func<long, long, T> getA = (row, col) => row < aRows && col < aCols ? readA(row, col) : zero;
    //    Func<long, long, T> getB = (row, col) => row < bRows && col < bCols ? readB(row, col) : zero;
    //    Action<long, long, T> setC = (row, col, value) =>
    //    {
    //        if (row < aRows && col < bCols) writeC(row, col, value);
    //    };
    //    var blockSize = new dim3(BlockSize, BlockSize);
    //    var gridSize = new dim3((int)ScalarOps.DivUp(aRows, BlockSize), (int)ScalarOps.DivUp(bCols, BlockSize));
    //    var lp = new LaunchParam(gridSize, blockSize);
    //    var stream = assignment.AttentionState.ToGpuContext().Stream;
    //    stream.Launch(Kernel, lp, aCols, getA, getB, setC, zero, add, mul);
    //    return true;
    //}
    
    if (assignment.Context.Type == ContextType.Cpu)
    {
    for (var i = 0L; i < aRows; ++i)
    {
    for (var j = 0L; j < bCols; ++j)
    {
    var acc = zero;
    for (var k = 0L; k < aCols; ++k)
    {
    acc = add(acc, mul(readA(i, k), readB(k, j)));
    }
    writeC(i, j, acc);
    }
    }
    return true;
    }
    
    return false;
    }
