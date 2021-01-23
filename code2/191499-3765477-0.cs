    void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            if (MessageBox.Show("An unexpected error has occurred.  You should exit this program as soon as possible.\n\n" +
                                "Exit the program now?\n\nError details:\n" + e.Exception.Message,
                                "Unexpected error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Shutdown();
        }
