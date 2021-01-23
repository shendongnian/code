    protected override void OnClosing(System.ComponentModel.CancelEventArgs e) 
    { 
        this.Visibility = Visibility.Hidden; 
        e.Cancel = true; 
    } 
