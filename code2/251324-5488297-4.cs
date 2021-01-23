    using System;
    using System.Runtime.InteropServices;
    namespace Tester
    {
        [ClassInterface(ClassInterfaceType.AutoDual)]
        public class TestClass
        {
            public double D { get; set; }  // simple property to get, set a double
            public string S { get; set; }  // simple property to get, set a string
        }
    }
