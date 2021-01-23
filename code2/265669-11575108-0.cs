                bool isOnlyInstance = false;
            Mutex m = new Mutex(true, @"WpfSingleInstanceApplication", out isOnlyInstance);
            if (!isOnlyInstance)
            {
                MessageBox.Show("Another Instance of the application is already running.", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            GC.KeepAlive(m);
