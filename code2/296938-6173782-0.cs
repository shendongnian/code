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
       [DllExport(CallingConvention = CallingConvention.StdCall)]
       [return: MarshalAs(UnmanagedType.IDispatch)]
       static Object CreateDotNetObject([MarshalAs(UnmanagedType.LPStr)] String text)
       {
          try
          {
             return new Sample { Text = text };
          }
          catch (Exception ex)
          {
             MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
             return null;
          }
       }
    }
