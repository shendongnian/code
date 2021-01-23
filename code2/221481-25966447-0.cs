     Task.Factory.StartNew(() =>
          {
            DoLongRunningWork();
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                  { txt.Text = "Complete"; }));
          });
