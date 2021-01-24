    [Test("BlockCopy", "", true)]
    public double[] Test1(double[,] input, int scale)
    {
       var width = input.GetLength(0);
       var height = input.GetLength(1);
       var size = width * height;
       var result = new double[size];
       Buffer.BlockCopy(input, 0, result, 0, size * sizeof(double));
       return result;
    }
    
    [Test("MarshalCopy", "", false)]
    public unsafe double[] Test2(double[,] input, int scale)
    {
       var width = input.GetLength(0);
       var height = input.GetLength(1);
       var size = width * height;
       var result = new double[size];
       fixed (double* pInput = input)
          Marshal.Copy((IntPtr)pInput, result, 0, size );
       return result;
    }
    
    [Test("ElemCopy", "", false)]
    public double[] Test3(double[,] input, int scale)
    {
       var width = input.GetLength(0);
       var height = input.GetLength(1);
       var size = width * height;
    
       var result = new double[size];
       for (var i = 0; i < width; i++)
          for (var j = 0; j < height; j++)
             result[i * height + j] = input[i,j];
       return result;
    }
    [Test("ElemCopy Unsafe", "", false)]
    unsafe public double[] Test4(double[,] input, int scale)
    {
       var width = input.GetLength(0);
       var height = input.GetLength(1);
       var size = width * height;
    
       var result = new double[size];
       fixed (double* pInput = input, pResult = result)
          for (var i = 0; i < width; i++)
             for (var j = 0; j < height; j++)
                *(pResult + i * height + j) = *(pInput + i * height + j);
       return result;
    }
    [Test("memcpy", "", false)]
    unsafe public double[] Test5(double[,] input, int scale)
    {
       var width = input.GetLength(0);
       var height = input.GetLength(1);
       var size = width * height;
    
       var result = new double[size];
       fixed (double* pInput = input, pResult = result)
          memcpy((IntPtr)pResult, (IntPtr)pInput, (UIntPtr)(size * sizeof(double)));
       return result;
    }
    [Test("Linq", "", false)]
    unsafe public double[] Test6(double[,] input, int scale)
    {
       return input.OfType<double>().ToArray();
    }
