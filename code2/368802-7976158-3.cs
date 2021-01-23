    StringBuilder sb = new StringBuilder(mainWindow.ChangeTextBox);
    foreach (AddEntry list in addedEntry)
    {
        sb.AppendLine(list.Type);
        if (list.DisplayType == 1) 
            sb.AppendLine("URL: " + list.URL);
        
        if (list.DisplayType == 0 || list.DisplayType == 1) {
            sb.AppendLine("User Name: " + list.UserName);
            sb.AppendLine("Password: " + list.Password);
        }
        if (list.DisplayType == 2) {
            sb.AppendLine("Software Name: " + list.SoftwareName);
            sb.AppendLine("Serial Code: " + list.SerialCode);
            sb.AppendLine("Software Name: " + list.SoftwareName);
        }
        sb.AppendLine();
    }  
 
    mainWindow.ChangeTextBox = sb.ToString();
