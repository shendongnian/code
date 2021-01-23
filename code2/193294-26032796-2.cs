    void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        IClosing context = DataContext as IClosing;
        if (context != null)
        {
            e.Cancel = !context.OnClosing();
        }
    }
