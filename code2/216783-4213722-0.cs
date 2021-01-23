    public abstract class A {
        public A(X, Y) {
        ...
        }
    
        public abstract Z TheVariableZ{get;set;}
    }
    
    public class B : A {
        public B(X, Y) : base(X, Y) {
            //i can only calculate Z here!
        }
    
        public override Z TheVariableZ{//implement it here}
    }
