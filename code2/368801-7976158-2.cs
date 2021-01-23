    StringBuilder sb = new StringBuilder(mainWindow.ChangeTextBox);
    foreach (AddEntry list in addedEntry)
    {
        var temp = list;
        sb.AppendLine(temp.Type);
        if (cmbType.SelectedIndex == 1) 
            sb.AppendLine("URL: " + temp.URL);
        
        if (cmbType.SelectedIndex == 0 || cmbType.SelectedIndex == 1) {
            sb.AppendLine("User Name: " + temp.UserName);
            sb.AppendLine("Password: " + temp.Password);
        }
        if (cmbType.SelectedIndex == 2) {
            sb.AppendLine("Software Name: " + temp.SoftwareName);
            sb.AppendLine("Serial Code: " + temp.SerialCode);
            sb.AppendLine("Software Name: " + temp.SoftwareName);
        }
        sb.AppendLine();
    }  
 
    mainWindow.ChangeTextBox = sb.ToString();
