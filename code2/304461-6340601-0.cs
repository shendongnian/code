    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
    public class Sample
    {
       public string Text
       {
          [return: MarshalAs(UnmanagedType.BStr)]
          get;
          [param: MarshalAs(UnmanagedType.BStr)]
          set;
       }
    
       [return: MarshalAs(UnmanagedType.BStr)]
       public string TestMethod()
       {
          return Text + "...";
       }
    }
    
    static class UnmanagedExports
    {
       [DllExport]
       [return: MarshalAs(UnmanagedType.IDispatch)]
       static Object CreateDotNetObject(String text)
       {
          return new Sample { Text = text };
       }
    }
