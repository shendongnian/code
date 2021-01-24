    void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ...other sync code...
            Task.Run(async () =>
            {
                await InvokeKmShutdown();
                (Dispatcher ?? Dispatcher.CurrentDispatcher).InvokeShutdown();
            });
        }
