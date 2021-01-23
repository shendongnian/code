      public class TaskData
        {
            private Action<int> Callback { get; private set; }
    
            public TaskData(Action<int> callbackAction)
            {
                this.Callback = callbackAction;
    
            }
    
            public void TriggerCallBack(int percentageComplete)
            {
                Action<int> handler = Callback;
    
                if (handler != null)
                {
                    handler(percentageComplete);
                }
            }
        }
