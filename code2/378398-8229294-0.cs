    public abstract class FooBase
    {
        protected abstract void DoSomeThing(); 
        protected abstract void SaveSomething();
        public void DoAndSave()
        {
            //Enforce Execution order
            DoSomeThing();
            SaveSomething();
        }
    
    }
    
    public class Foo : FooBase
    {
        protected override void DoSomeThing()
        {
            /*code to calculate results*/
        }
    
        protected override void SaveSomething()
        {
            /* code to save the results in DB*/
        }
    }
