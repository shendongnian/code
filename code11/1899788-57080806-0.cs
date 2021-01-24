    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Text;
    
    namespace SerialPortCommunication
    {
        public delegate void UpdateLogDelegate(string msg);
    	public UpdateLogDelegate ULD;	//create instance of your delegate that you will assign a function to
    
        public partial class button : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            public void UpdateLog(string msg)
            {
    			//the serial port datareceived event is on a different thread
    			//you'll have to invoke to update your GUI
    			this.Invoke((MethodInvoker)delegate
    			{
    				lblLog.Text = msg;
    			});
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                var request = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
    
                SerialPort port = new SerialPort("COM8");
    
                port.BaudRate = 19200;
                port.Parity = Parity.Even;
                port.StopBits = StopBits.One;
                port.DataBits = 7;
    			port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);	//move this before you write to the port
    			
    			//initialize your delegate to the UpdateLog function
    			//but note, maybe if you had a Button2_click you could set ULD to a different
    			//function and as data came in it would just call the correct function
    			ULD = UpdateLog;	
    
                port.Open();
    
                port.Write(request, 0, request.Length);
            }
    
    		public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    		{
    			//your port is already global so you dont need to re-declare it
    			string incomingData = port.ReadExisting();
    
    			ULD(incomingData);
    
    			port.Close();	//I wouldn't close the port here, but for testing this is ok
    		}
    	}
    }
