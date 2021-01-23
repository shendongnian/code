    class Program
    {
      private static Assembly _asm;
      
      private static Assembly getExternalDll()
      {
        if (_asm == null)
          _asm = Assembly.LoadFile("SomeExternal.dll");
        return _asm;
      }
      static void Main(string[] args)
      {
        DoSomething();
        DoSomeMoreStuff();
        // More of such method calls that each 
        // call Assembly.LoadFile()
      }
      static void DoSomething()
      {
        var asm = getExternalDll();
        // stuff happens...
      }
      static void DoSomeMoreStuff()
      {
        var asm = getExternalDll();
        // stuff happens...
      }
    }
