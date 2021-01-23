        using System;
        using System.Runtime.InteropServices;
    
        namespace SOExampleNew
        {
          [ComVisible(true)]  // This is mandatory.
          [Guid("3E9D5340-A266-4D06-8A6D-C2B72B996883")]
          [InterfaceType(ComInterfaceType.InterfaceIsDual)]
          public interface ITestCls
          {
            [DispId(1)]
            int Add(int a, int b);
            [DispId(2)]
            string SayHello(string input);
          }
       
          [ComVisible(true)]  // This is mandatory.
          [Guid("5CD3AED7-971C-443E-9B6C-2E9CC2C8F350")]
          [ClassInterface(ClassInterfaceType.None)]
          [ProgId("SOExampleNew.TestCls")]
          public class TestCls : ITestCls
          {
            // A default public constructor is also mandatory.
            public TestCls(){ }
        
            ~TestCls(){}
        
            public int Add(int a, int b)
            {
              return a + b;
            }
        
            public string SayHello(string input)
            {
              return "Hello " + input;
            }
          }
        }
  
