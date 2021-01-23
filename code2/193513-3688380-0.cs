    public class Action : IAction {
        public void DoSomething() {
            MyStaticClass.DoSomethingThatIsBadForUnitTesting();
        }
    }
