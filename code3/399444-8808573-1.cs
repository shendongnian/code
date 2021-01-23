    Task.Factory.StartNew(
        () =>
            {
                Parallel.ForEach(myList, 
                    value =>
                    {
                        string result = TimeConsumingTask(value);
                        //update UI
                        Application.Current.Dispatcher.BeginInvoke(
                           (Action)(() => listBox.Add(result)));
                    });            
            });
        }
