    Something obj = new Something();
    
    // Outputs "Hello World!"
    obj.SayHi();
    ISomething iObj = obj;
    // Outputs "42!"
    iObj.SayHi();
