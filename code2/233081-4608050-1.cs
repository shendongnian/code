    TestClass tc1 = new TestClass(new MyStaticMethodInvoker(TestStatic.TestMethod1));
    tc1.CallTargetedStaticMethod();
    
    TestClass tc2 = new TestClass(new MyStaticMethodInvoker(TestStatic.TestMethod2));
    tc2.CallTargetedStaticMethod();
    
    TestClass tc3 = new TestClass(new MyStaticMethodInvoker(TestStatic.TestMethod3));
    tc3.CallTargetedStaticMethod();
