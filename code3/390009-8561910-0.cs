    class A<T> where T : BaseClass {
        protected virtual void Method(T bc) { ... }
    }
    class B : A<DerivedClass> {
        protected override void Method(DerivedClass bc) {
            bc.DerivedClassField = blabla;
        }
    }
