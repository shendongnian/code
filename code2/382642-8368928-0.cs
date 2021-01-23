    using System.IO.Ports;    
    static void ParseData(ref string data)
    {
        data = data.TrimStart(new char[] { (char)02 }); 
        data = data.TrimEnd(new char[] { (char)03 });  
    }    
    private void UpdateControlsWithData(string data)
    {
        Action action;
        if(data.StartsWith("C")
        {
            action = () => ClearAll();
        }
        else if(data.StartsWith("W98"))
        {
            action = () => { txtTax.Text = data.Remove(0, 5); };
        }
        else if(data.StartsWith("W99"))
        {
            action = () => { txtTotal.Text = data.Remove(0, 24); };
        }
        else
        {
            action = () => { 
                listOrderItems.Items.Add(data.Remove(0, 5));
                listOrderItems.SelectedIndex = listOrderItems.Items.Count - 1;
            };
        }
        if(this.InvokeRequired()) this.Invoke(action);
        else action();
    }
    private void HandleDataReceived()
    {
        string data = serialPort1.ReadTo("\u0003");
        ParseData(ref data);
        UpdateControlsWithData(data);
    }
    
    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        this.HandleDataReceived();
    }
