            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
                InputManager.Current.PreProcessInput += new PreProcessInputEventHandler(Current_PreProcessInput);
            }
    
            private void Current_PreProcessInput(object sender, PreProcessInputEventArgs e)
            {
                if (e.StagingItem.Input is MouseEventArgs
                        || e.StagingItem.Input is KeyboardEventArgs
                        || e.StagingItem.Input is TextCompositionEventArgs
                        )
                {
                    if (e.StagingItem.Input is MouseEventArgs)
                    {
                        MouseEventArgs mouseEventArgs = (MouseEventArgs)e.StagingItem.Input;
    
                        // no button is pressed and the position is still the same as the application became inactive
                        if (mouseEventArgs.LeftButton == MouseButtonState.Released &&
                            mouseEventArgs.RightButton == MouseButtonState.Released &&
                            mouseEventArgs.MiddleButton == MouseButtonState.Released &&
                            mouseEventArgs.XButton1 == MouseButtonState.Released )
                            return;
                    }
    
                    // User activity log for testing
                    Debug.WriteLine("Got the event :" + e.StagingItem.Input.ToString());
                }
            }
