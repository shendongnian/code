    Test test = new Test();
    // Doesn't compile: private method call
    test.Test(); 
    // ITest.Test() call which is OK
    (test as ITest).Test();
 
