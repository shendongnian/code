    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       _DisableBorder.Visibility = System.Windows.Visibility.Visible; 
       System.Windows.Forms.Application.DoEvents();
       Thread.Sleep(2000);
    }
