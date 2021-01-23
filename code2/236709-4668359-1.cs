    public class MyForm : Form
    {
       Thread _thread;
    
        private void button_Click(object sender, RoutedEventArgs e)
        {
            _thread = new Thread(Process);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Name = "ProcessThread";
            _thread.Start();
        }
    
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        
            if (_thread.IsAlive)
                //....
    
            string msg = "Really close?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Closing",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
