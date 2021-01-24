     private async void SQzero_Click(object sender, RoutedEventArgs e)
        {
            int EndTime = 4000;
            SQZero.Visibility = Visibility.Hidden;
            System.Windows.MessageBox.Show("Stop Writing CSV... \nWait a Seconds..", "CSV Saving..", MessageBoxButton.OK, MessageBoxImage.Warning);
            GaugeSignal.Value = 0;
            await Task.Delay(EndTime);    //Wait for Delay of CSVexport_btn
            System.Windows.MessageBox.Show("CSV Saved!", "CSV Saved", MessageBoxButton.OK, MessageBoxImage.Warning);
            CSVexport.Visibility = Visibility.Visible;  //to Save another one Again
        }
