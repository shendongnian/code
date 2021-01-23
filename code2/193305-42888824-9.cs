    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    { 
        if (((ViewModel.MainViewModel)DataContext).CancelBeforeClose())
            e.Cancel = true;
    }
