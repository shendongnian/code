    StringBuilder sb = new StringBuilder();
    foreach (AddEntry list in addedEntry)
    {
    	sb.AppendLine();
    	if (!string.IsNullOrEmpty(list.URL))
    	sb.AppendLine("URL: " + list.URL);
    	if (!string.IsNullOrEmpty(list.SoftwareName))
    	sb.AppendLine("Software Name: " + list.SoftwareName);
    	if (!string.IsNullOrEmpty(list.SerialCode))
    	sb.AppendLine("Serial Code: " + list.SerialCode);
    	if (!string.IsNullOrEmpty(list.UserName))
    	sb.AppendLine("User Name: " + list.UserName);
    	if (!string.IsNullOrEmpty(list.Password))
    	sb.AppendLine("Password: " + list.Password);
    	sb.AppendLine();
    }
