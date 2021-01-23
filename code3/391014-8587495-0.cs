    interface IAction
    {
        void Do();
    }
        class SubClass : IAction
        {
            object _param;
            public SubClass(object o)
            {
                _param = o;
            }
            public void Do()
            {
               // your current code in here
            }
        }
            SubClass sc = new SubClass("paramter");
            System.Threading.ThreadPool.QueueUserWorkItem(action => {
                var dosomething = action as IAction;
                dosomething.Do();
            }, sc);
