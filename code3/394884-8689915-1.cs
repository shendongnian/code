    class Derived : Base {
        public override object Var {
            get { return null; }
            protected set { // <------ added protected here
            }
        }
    }
