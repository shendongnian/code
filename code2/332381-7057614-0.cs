    public void SomeHandlerMethod(bool b) { ... }
 
    ...
    someInstance.CommittedChanged += SomeHandlerMethod;
    someInstance.CommittedChanged += ASecondHandlerMethod;
    someInstance.CommittedChanged += x => { /* inline handler using lambda */ };
    
