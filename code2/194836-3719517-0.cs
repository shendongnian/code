    txtLog.Dispatcher.Invoke(
        (Action)(() =>
            {
                txtLog.Text = dataToDisplay;
                extendedNotifyIcon_OnShowWindow(); 
                new Timer(
                    (state) =>
                    {
                        button1.Dispatcher.BeginInvoke(
                            (Action)(() =>
                                {
                                  extendedNotifyIcon_OnHideWindow(); 
                                }), null);
                    }, null, 1000, Timeout.Infinite);
            }));
