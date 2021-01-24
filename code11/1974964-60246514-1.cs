    interface A
    {
        void DoSomething();
    }
    interface B
    {
        void DoSomething();
    }
    class C : A, B {
        public void DoSomething() { }
    }
