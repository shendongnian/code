    class A {
        public void Foo() {}
    }
    class B : A {}
    class C {
        void Bar(){
             B b = new B();
             b.Foo(); // Works
        }
    }
