            protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
            {
                try
                {
                    // there is a bug (throw CrossThreadException) in notifyIcon when disposing from ViewModel.
                    notifyIcon.Dispatcher.Invoke(new Action(delegate
                    {
                        notifyIcon.Dispose();
                    }));
                }
                catch { }
                base.OnClosing(e);
            }
