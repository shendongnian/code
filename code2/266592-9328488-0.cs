    using System;
    using System.Diagnostics;
    public static class Program {
    private const Int32 c_numElements = 10000;
    public static void Main() {
    const Int32 testCount = 10;
    Stopwatch sw;
    // Declare a two-dimensional array
    Int32[,] a2Dim = new Int32[c_numElements, c_numElements];
    // Declare a two-dimensional array as a jagged array (a vector of vectors)
    Int32[][] aJagged = new Int32[c_numElements][];
    for (Int32 x = 0; x < c_numElements; x++)
    aJagged[x] = new Int32[c_numElements];
    // 1: Access all elements of the array using the usual, safe technique
    sw = Stopwatch.StartNew();
    for (Int32 test = 0; test < testCount; test++)
    Safe2DimArrayAccess(a2Dim);
    Console.WriteLine("{0}: Safe2DimArrayAccess", sw.Elapsed);
    // 2: Access all elements of the array using the jagged array technique
    sw = Stopwatch.StartNew();
    for (Int32 test = 0; test < testCount; test++)
    SafeJaggedArrayAccess(aJagged);
    Console.WriteLine("{0}: SafeJaggedArrayAccess", sw.Elapsed);
    // 3: Access all elements of the array using the unsafe technique
    sw = Stopwatch.StartNew();
    for (Int32 test = 0; test < testCount; test++)
    Unsafe2DimArrayAccess(a2Dim);
    Console.WriteLine("{0}: Unsafe2DimArrayAccess", sw.Elapsed);
    Console.ReadLine();
    }
    private static Int32 Safe2DimArrayAccess(Int32[,] a) {
    Int32 sum = 0;
    for (Int32 x = 0; x < c_numElements; x++) {
    for (Int32 y = 0; y < c_numElements; y++) {
    sum += a[x, y];
    }
    }
    return sum;
    }
    private static Int32 SafeJaggedArrayAccess(Int32[][] a) {
    Int32 sum = 0;
    for (Int32 x = 0; x < c_numElements; x++) {
    for (Int32 y = 0; y < c_numElements; y++) {
    sum += a[x][y];
    }
    }
    return sum;
    }
    private static unsafe Int32 Unsafe2DimArrayAccess(Int32[,] a) {
    Int32 sum = 0;
    fixed (Int32* pi = a) {
    for (Int32 x = 0; x < c_numElements; x++) {
    Int32 baseOfDim = x * c_numElements;
    for (Int32 y = 0; y < c_numElements; y++) {
    sum += pi[baseOfDim + y];
    }
    }
    }
    return sum;
    }
    }
