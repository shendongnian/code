        using System.Runtime.InteropServices;
        namespace SOExampleNew
        {
          [ComVisible(true)]  // This is mandatory.
          [InterfaceType(ComInterfaceType.InterfaceIsDual)]
          public interface ITestCls
          {
            int Add(int a, int b);      // A method
            string TheName { get; set;} // A property
          }
          [ComVisible(true)]  // This is mandatory.
          [ClassInterface(ClassInterfaceType.None)]
          [ProgId("SOExampleNew.TestCls")]
          public class TestCls : ITestCls
          {
            private string mName = "Bert";
            // A default public constructor is also mandatory.
            public TestCls() { }
            public int Add(int a, int b){ return a + b; }
            public string TheName { get { return mName; } set { mName = value; } }
          }
        }
  
