    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        Password passwordentry = new Password();
        passwordentry.ShowDialog();
    
        if (Application.Current.Properties["PassGate"].ToString() == "mypassword")
        {
            Code, or call to delete the record;
        }
        Application.Current.Properties["PassGate"] = "";
    }
