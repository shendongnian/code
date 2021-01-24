    private bool _forceClose;
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if(!_forceClose) 
        {
            e.Cancel = true;
            this.Hide();
        }
    }
    void closeButton_Click(object sender, RoutedEventArgs e)
    {
        _forceClose = true;
       Close();
    }
