    SerialPort sp;
    
    private void buttonOpen_Click(object sender, EventArgs e)
    {
    	if (sp != null)
    		return;
    
    	if (string.IsNullOrEmpty(cb1.SelectedItem.ToString())) 
    	{
    		MessageBox.Show("Er is nog niet een selectie gemaakt ");
    		return;
    	}
    
    	sp = new SerialPort();
    	sp.PortName = "COM1";	//put your comport # here
    	sp.BaudRate = 9600;
    	sp.DataBits = 8;
    	sp.Parity = Parity.None;
    	sp.StopBits = StopBits.One;
    	sp.Handshake = Handshake.None;
    	sp.DataReceived += new SerialDataReceivedEventHandler(artikel_DataReceived);
    	
    	sp.Open();
    }
    
    private void buttonClose_Click(object sender, EventArgs e)
    {
    	sp.DataReceived -= new SerialDataReceivedEventHandler(artikel_DataReceived);
    	sp.Close();
    	sp.Dispose();
    }
    
    private void artikel_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
    	string Data = sp.ReadExisting();
    
    	this.Invoke((MethodInvoker)delegate
    	{
    		textBox1.Text += Data;
    	});
    }
