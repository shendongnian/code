    class Derived : Base
    {
        private Action[] AllActions;
        public Derived()
        {
            AllActions = new Action[] 
            {
                base.DoSomething1,
                base.DoSomething2,
                base.DoSomethingMore
            };
        }
        public ActionWrapper(int index)
        {
            try
            {
                AllActions[index].Invoke();
            } catch(Exception e)
            {
                Log(e.Message);
            }
        }
    }
