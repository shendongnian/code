       [DllImport("UnmanagedCpp.dll", CallingConvention=CallingConvention.Cdecl)]
       public static extern int fnUnmanagedCpp(IntPtr[] buffer, int nRows, int nCols );
    
       public static IntPtr[] Marshall2DArray(byte[][] inArray)
       {
           IntPtr[] rows = new IntPtr[inArray.Length];
    
           for ( int i = 0; i < inArray.Length; ++i )
           {
               rows[i] = Marshal.AllocHGlobal(inArray[i].Length * Marshal.SizeOf(typeof(byte)));
               Marshal.Copy( inArray[i], 0, rows[i], inArray[i].Length );
           }
           
           return rows;
       }
    
       public static void Copy2DArray( IntPtr[] inArray, byte[][] outArray )
       {
           Debug.Assert(inArray.Length == outArray.Length);
    
           int nRows = Math.Min( inArray.Length, outArray.Length );
    
           for (int i = 0; i < nRows; ++i)
           {
               Marshal.Copy(inArray[i], outArray[i], 0, outArray[i].Length);
           }
       }
    
       public static void Free2DArray(IntPtr[] inArray)
       {
           for (int i = 0; i < inArray.Length; ++i)
           {
               Marshal.FreeHGlobal(inArray[i]);
           }
       }
    
        static void Main(string[] args)
        {
            byte[][] bTest = new byte[2][] { new byte[2] { 1, 2 }, new byte[2] { 3, 4 } };
    
            IntPtr[] inArray = Marshall2DArray(bTest);
    
            fnUnmanagedCpp(inArray, 2, 2);
    
            Copy2DArray(inArray, bTest);
            Free2DArray(inArray);
    
            System.Console.WriteLine(bTest[0][0]);
        }
