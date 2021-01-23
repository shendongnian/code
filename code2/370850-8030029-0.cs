    System.Text.StringBuilder sbText = new System.Text.StringBuilder(10000);
    
    foreach (string sFile in files) {
      sbText.AppendLine(sFile);
    }
    
    TextBox1.Text = sbText.ToString();
