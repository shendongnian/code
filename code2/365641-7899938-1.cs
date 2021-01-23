    namespace nmspA {
        public class A{
            private void DoSomething(){
                B.Foo(this);
            }
        }
    }
    namespace nmspB {
        public class B {
            public static void Foo(A a){
                Debug.Write(a.GetType()); // Will write : "nmspA.A"
            }
        }
    }
