    public class BaseClass {
        public virtual void DoSomething() {
        }
    }
    public class SubClass : BaseClass {
        public override void DoSomething() {
        }
        public void DoSomethingElse() {
            DoSomething(); // Calls SubClass
            base.DoSomething(); // Calls BaseClass
        }
    }
