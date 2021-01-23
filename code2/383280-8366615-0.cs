      class MyClass
      {
      [DllImport("MyDLL.dll")]
      public static extern void MyFunctionFromDll();
            static void Main()
            {
                  MyFunctionFromDll();
            }
      }
