    public void DoSomething(IB ib) // given 
    
    A a = new A();
    DoSomething(new ABAdapter(a)); // invoke with A
    DoSomething(new B()); // invoke with B
