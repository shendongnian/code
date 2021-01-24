    [DllImport("WinApiFunction")]
    public static extern bool WinApiFunction(int arg1, int arg2, out IntPrt result)
    public void Foo()
    {
      var result = IntPtr.Zero;
      if (!WinApiFunction(1, 2, out result) || result == IntPtr.Zero)
      {
        throw new Exception("Oops");
      }
      try
      {
        Foo1(result);
        Foo2(result);
      }
      finally
      {
        CloseHandle(result);
      }
    }
