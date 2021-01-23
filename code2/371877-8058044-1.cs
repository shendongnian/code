            Thread thread = new Thread(() => {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => {
                    MyWindow windowInAnotherThread = new MyWindow();
                    windowInAnotherThread.Show();
                }));
                System.Windows.Threading.Dispatcher.Run();
            }) { IsBackground = true };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
