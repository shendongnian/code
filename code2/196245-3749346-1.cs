    private void AcceptButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Properties["PassGate"] = PasswordTextBox.Text;
        this.Close();
    }
