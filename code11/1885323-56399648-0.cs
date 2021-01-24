    //private variables
    private SerialPort sp;
    private StringBuilder sb;
    private char LF = (char)10;
    
    //function to initialize all my objects
    public void init_state_machine()
    {
    	sp = new SerialPort(currentSettings.ComPort, currentSettings.BaudRate);
    	sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
    
    	sb = new StringBuilder();
    	sb.Clear();
    }
    
    private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
    	string currentLine = "";
    	string Data = sp.ReadExisting();
    
    	foreach (char c in Data)
    	{
    		if (c == LF)
    		{
    			sb.Append(c);
    
    			//because it's threaded its possible to enter this code while processing so we will
    			//clear our string building immediately
    			currentLine = sb.ToString();
    			sb.Clear();
    			
    			//process your line here or whatever
    			processReceivedData(currentLine);
    		}
    		else
    		{
    			sb.Append(c);
    		}
    	}
    }
    
    //this is where you process the response.  For a simple example I just append the string
    //to our textbox, but you could do any computations in here.
    private void processReceivedData(string s)
    {
    	this.BeginInvoke((MethodInvoker)delegate 
    	{
    		serialTextBox.Text += s;
    	});
    }
