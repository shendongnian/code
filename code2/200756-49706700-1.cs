    private void InitializeKeyboardHookWithSeparateDispatcher()
        {
            using (var objCreated = new ManualResetEventSlim(false))
            {
                var thread = new Thread(() =>
                {
                    _keyboardListener = new KeyboardListener();
                    // ReSharper disable once AccessToDisposedClosure
                    objCreated.Set();
                    System.Windows.Threading.Dispatcher.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
                objCreated.Wait();
            }
        }
