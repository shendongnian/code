    void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string str = this.serialPort1.ReadLine();
        if (!string.IsNullOrEmpty(str))
        {
            ShowCustomerData(str);
        }   
    
    }
    
    private delegate void ShowCustomerDataDelegate(string s);
    
    private void ShowCustomerData(string s)
    {
        if (Main.Instance.InvokeRequired)
        {
            Main.Instance.Invoke(new ShowCustomerDataDelegate(ShowCustomerData), s);
        }
        else
        {
    
            Main.Instance.customerData = new CustomerData(str);
            Main.Instance.customerData.MdiParent = Main.Instance;  //Exeption received at this point
            Main.Instance.customerData.Disposed += new EventHandler(customerData_Disposed);
    
            Main.Instance.customerData.Show();
        }
    }
