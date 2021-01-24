    SerialPort sp;
    Timer tm;
    private void init_ports()
    {
    	//Setup our Serial Port
    	sp = new SerialPort();
    	sp.NewLine = "\r\n";
    	sp.PortName = this.PortName;
    	sp.BaudRate = this.BaudRate;
    	sp.Parity = Parity.None;
    	sp.DataBits = 8;
    	sp.StopBits = StopBits.One;
    	sp.Handshake = Handshake.None;
    	sp.DtrEnable = true;
    	sp.WriteBufferSize = 1024;
    	sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
    
    	//Setup our Timer
    	tm = new Timer();
    	tm.Tick += new EventHandler(tm_Tick);
    	tm.Interval = 1000; //in ms
    	tm.Enabled = true;  //Start our timer
    }
    
    void tm_Tick(object sender, EventArgs e)
    {
    	if (!sp.IsOpen)
    		sp.Open();
    
    	sp.Write("C");
    }
    
    void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
    	string indata = sp.ReadExisting();
    	Console.WriteLine("Data Received:");
    	Console.Write(indata);
    }
