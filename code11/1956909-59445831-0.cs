    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to close the window",
            "Close?", MessageBoxButton.YesNoCancel,
            MessageBoxImage.Question, MessageBoxResult.Cancel) != MessageBoxResult.Yes)
        {
            e.Cancel = true;
        }
    }
    private void Window_Closed(object sender, EventArgs e)
    {
        MessageBox.Show("Window closed.");
    }
