    class A {
        public virtual int Hello() {
            return 1;
        }
    }
    
    class B : A {
        new public int Hello(object newParam) {
            return 2;
        }
    }
    
    class C : A {
        public override int Hello() {
            return 3;
        }
    }
