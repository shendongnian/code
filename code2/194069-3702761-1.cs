    A a = new A();
    A bAsA = new B();
    A cAsA = new C();
    B b = new B();
    B cAsB = new C();
    C c = new C();
    a.DoSomething(); // 42!
    b.DoSomething(); // Not 42!
    bAsA.DoSomething(); // 42!
    c.DoSomething(); // 43!
    cAsB.DoSomething(); // 43!
    cAsA.DoSomething(); // 42!
