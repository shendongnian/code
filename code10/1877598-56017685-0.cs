     public class AllActions
    {
        public void DoSomething() {...}
        public void DoSomethingElse() {...}
    
        public void DoEverything()
        {
            DoSomething();
            DoSomethingElse();
        }
    
    }
    
    // Call the method to do everything you want
    protected void button_Click(object sender, EventArgs e)
    {
        var allButtonActions = new AllActions();
        allButtonActions.DoEverything();
    }
