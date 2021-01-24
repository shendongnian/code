using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void ClassInit(TestContext tc)
        {
            throw new Exception("DIE IN INITIALIZE");
        }
        [TestMethod] public void TestMethod1() { }
        [TestMethod] public void TestMethod2() { }
        [TestMethod] public void TestMethod3() { }
    }
}
And indeed if you look at the results in TestExplorer, you can see that only `TestMethod1` is marked as Failed, while `TestMethod2` and `TestMethod3` are marked as `Successful`.
Same result from the console.
❯ dotnet test
Test run for C:\source\stuff\UnitTestProject1\UnitTestProject2\bin\Debug\netcoreapp3.1\UnitTestProject2.dll(.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.3.0
Copyright (c) Microsoft Corporation.  All rights reserved.
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
  X TestMethod1
  Error Message:
   Class Initialization method UnitTestProject2.UnitTest1.ClassInit threw exception. System.Exception: System.Exception: DIE IN INITIALIZE.
  Stack Trace:
     at UnitTestProject2.UnitTest1.ClassInit(TestContext tc) in C:\source\stuff\UnitTestProject1\UnitTestProject2\UnitTest1.cs:line 12
Test Run Failed.
Total tests: 3
     Passed: 2
     Failed: 1
 Total time: 0,8928 Seconds
Interestingly, if you add some `Console.WriteLine` statements to the test methods, you can see, that indeed they are really executed. So it doesn't seem to be a mishap in the output only.
**Update** Not sure if this is to be expected, but I submitted an issue for it https://github.com/microsoft/testfx/issues/672.
