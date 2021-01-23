    public void Scan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        if (e.Error != null) {
            // You have an exception, which you can examine through the e.Error property.
        } else {
            // No exception in DoWork.
            try {
                if (ScanResults.Count == 0) {
                    System.Windows.Forms.MessageBox.Show("Empty");
                    return;
                }
                MachineNameBox.Text = ScanResults[0];
            } catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message, "Error Encountered", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
