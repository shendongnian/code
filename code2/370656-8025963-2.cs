        public static void DoSomeHardWork(Action<Window, object> toDo, object actionParams)
        {
            Thread windowThread = new Thread(() =>
            {
                Window waitWindow = new Window();
                waitWindow.Loaded += (s, e) =>
                {
                    Thread workThread = new Thread(() =>
                    {
                        // Run work method in work thread passing the
                        // wait window as parameter
                        toDo(waitWindow, actionParams);
                    }) { IsBackground = true };
                    // Start the work thread.
                    workThread.Start();
                };
                waitWindow.Show();
                Dispatcher.Run();
            }) { ApartmentState = ApartmentState.STA, IsBackground = true };
            // Start the wait window thread.
            // When window loads, it will create work thread and start it.
            windowThread.Start();
        }
        private void MyWork(Window waitWindow, object parameters)
        {
            for (int i = 0; i < 10; i++)
            {
                // Report progress to user through wait window.
                waitWindow.Dispatcher.BeginInvoke((Action)(() => waitWindow.Title = string.Format("{0}: {1}", parameters, i)), DispatcherPriority.Normal);
                // Simulate long work.
                Thread.Sleep(500);
            }
            // The work is done. Shutdown the wait window dispather.
            // This will stop listening for events and will eventualy terminate
            // the wait window thread.
            waitWindow.Dispatcher.InvokeShutdown();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DoSomeHardWork(MyWork, DateTime.Now);
        }
