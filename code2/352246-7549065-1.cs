    Application.Current.Dispatcher.Invoke(
        DispatcherPriority.Normal, 
        new Action(() =>
                    {
                        Form1 f = new Form1();
                        f.Show();
                        System.Threading.Thread.Sleep(3000);
                    }));
