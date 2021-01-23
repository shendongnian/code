      public override string ToString() 
      {
    	StringBuilder sb = new StringBuilder();
    	sb.AppendLine();
    	if (!string.IsNullOrEmpty(this.URL))
    	sb.AppendLine("URL: " + list.URL);
    	if (!string.IsNullOrEmpty(this.SoftwareName))
    	sb.AppendLine("Software Name: " + this.SoftwareName);
    	if (!string.IsNullOrEmpty(this.SerialCode))
    	sb.AppendLine("Serial Code: " + this.SerialCode);
    	if (!string.IsNullOrEmpty(this.UserName))
    	sb.AppendLine("User Name: " + this.UserName);
    	if (!string.IsNullOrEmpty(this.Password))
    	sb.AppendLine("Password: " + this.Password);
    	sb.AppendLine();
    	return sb.ToString();
      }
