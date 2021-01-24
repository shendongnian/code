    class A
    {
        public void DoSomething() {}
    }
    class B
    {
        public void DoSomething() {}
    }
    class C : A, B { }
    C c = new C();
    c.DoSomething(); // which DoSomething() is it?
