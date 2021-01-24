    public interface IDoesSomething
    {
        void DoSomething();
    }
    public class DoesSomething : IDoesSomething
    {
        public void DoSomething()
        {
            DoAnotherThing();
            DoOneThing();
            SomethingElse();
        }
    
        private void DoOneThing(){}
        private void DoAnotherThing(){}
        private void SomethingElse(){}
    }
