    void officeApps_Exited(object sender, EventArgs e)
    {
    System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)delegate()
                     {
            MessageBox.Show("I am back");
            // do further processing
     });
    }
