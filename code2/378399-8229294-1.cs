    public abstract class FooBase
    {
        protected abstract void DoSomeThing();
        protected abstract void SaveSomething();
        protected abstract bool AreValidResults();
        public void DoAndSave()
        {
            //Enforce Execution order
            DoSomeThing();
    
            if (AreValidResults())
                SaveSomething();
        }
    
    }
