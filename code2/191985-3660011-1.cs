      class Program
      {
        static void Main(string[] args)
        {
          string[] data;
          bool b = GetStringArr(out data);      
        }
    
        [DllImport("CppDll.dll", 
                   CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetStringArr(
          [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VarEnum.VT_BSTR)] 
          out string[] strServerList);    
      }
