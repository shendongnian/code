                    Task.Factory.StartNew(
                            () =>
                            {
                                if ((bool)Dispatcher.Invoke(DispatcherPriority.Normal, new Func<bool>(() =>
                                {
                                     return Keyboard.Modifiers == ModifierKeys.Alt;
                                 })))
                                 {
                                    Thread.Sleep(1000);                            
                                 }
                            })
                            .ContinueWith(t =>
                            {
                              // do somthing
                            });
