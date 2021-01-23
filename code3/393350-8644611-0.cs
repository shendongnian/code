     Dispatcher.Invoke(DispatcherPriority.Normal, 
                        new Action(
                delegate()
                {
                  DisplayTextBox.Text = Convert.ToString(str);
                }
            ));
