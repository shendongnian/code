    dynamic a = new A();
    dynamic b = new B();
    var h = new Helper();         
    h.DoSomething(a); // will be called DoSomething(A o)        
    h.DoSomething(b); // will be called DoSomething(B o)
