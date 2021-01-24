    Test test = new Test();
    // ITest.Test() call which is OK
    (test as ITest).Test();
    // Doesn't compile: 
    //   1. Private method
    //   2. Wrong name; should be ITest.Test() which is not allowed 
    test.Test(); 
 
