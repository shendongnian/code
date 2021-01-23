    Task.Factory.StartNew(
        () =>
            {
                foreach (string value in myList)
                {
                    string result = TimeConsumingTask(value);
                    //update UI
                    Application.Current.Dispatcher.BeginInvoke(
                        (Action)(() => listBox.Add(result)));
                }            
            });
