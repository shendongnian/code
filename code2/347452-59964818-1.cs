    private class ExampleTask : AsyncTask
        {
            protected override void DoInBackground()
            {
                //Background process. 2nd thread
            }
            protected override void PreExecute()
            {
                //Main thread. Before executing DoInBackground
            }
            protected override void TaskCompleted()
            {
                //Main thread. Task Completed
            }
        }
