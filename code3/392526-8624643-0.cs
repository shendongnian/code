    private void TaskUse()
        {
            var task = new Task<string>(() =>
                {
                    Thread.Sleep(5000);
                    return "5 seconds passed!";
                });
            task.ContinueWith((tResult) =>
                {
                    TestTextBox.Text = tResult.Result;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();
        }
