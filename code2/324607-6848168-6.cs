        private class BaseClass
        {
            public virtual void SomeMethod(){}
        }
        private class ChildClass : BaseClass
        {
            public new void SomeMethod() //<- Declaring new method will block proxy
            {
                base.SomeMethod();
            }
        }
        private class ChildClassIocProxy : ChildClass
        {
            public override void SomeMethod() //<-- Not possible!
            {
                //Injected - before Tx
                base.SomeMethod();
                //Injected - after Tx
            }
        }
