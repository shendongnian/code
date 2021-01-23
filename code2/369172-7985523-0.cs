    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
            {
    
                try
                {
                    SerialPort sp = (SerialPort)sender;
                    string indata = sp.ReadExisting();
                    this.txLabel.Text = "testttingg";
                }
                //more code
             }
