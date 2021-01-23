    string newFileName = "C:\\client_20100913.csv";
    
    string clientDetails = clientNameTextBox.Text + "," + mIDTextBox.Text + "," + billToTextBox.Text;
    
    
    if (!File.Exists(newFileName))
    {
        string clientHeader = "Client Name(ie. Billto_desc)" + "," + "Mid_id,billing number(ie billto_id)" + "," + "business unit id" + Environment.NewLine;
    
        File.WriteAllText(newFileName, clientHeader);
    }
    
    File.AppendAllText(newFileName, clientDetails);
