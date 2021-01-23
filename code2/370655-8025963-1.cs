            // reference to window in another thread
            Window outputWindow = null;
            Thread thread = new Thread(() =>
            {
                // another thread
                outputWindow = new Window();
                outputWindow.Show();
                // run event loop
                System.Windows.Threading.Dispatcher.Run();
            }) { ApartmentState = ApartmentState.STA, IsBackground = true };
            thread.Start();
            while (outputWindow == null)
            {
                // wait until the window in another thread has been created
                Thread.Sleep(100);
            }
            // simulate process
            for (int i = 0; i < 10; i++)
            {
                outputWindow.Dispatcher.BeginInvoke((Action)(() => { outputWindow.Title = i.ToString(); }), System.Windows.Threading.DispatcherPriority.Normal);
                Thread.Sleep(500); // simulate some hard work so we can see the change on another window's title
            }
            // close the window or shutdown dispatcher or abort the thread...
            thread.Abort();
