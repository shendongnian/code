    private SerialPort _serialPort;
    ...
    private void Main()
    {
        ...
    	Open();			// Open COM Port
        ...				// Do Stuff
    
    }
    ...
    // COM Port removed event
    private void PortCOMRemoved()
    {
        ...
    	Close(true);
        ...
    }
    ...
    private void Close(bool currentCOMPortRemoved = false)
    {    
        ...
	    if (currentCOMPortRemoved)
    	{
    		_serialPort.DtrEnable = false;
    		_serialPort.RtsEnable = false;
    		_serialPort.DiscardInBuffer();
    		_serialPort.DiscardOutBuffer();
    		// Do not close the COM Port, otherwise, it will freeze
    		// This is a Bug in SerialPort class management Framework
    		// On next connexion, it will create a new SerialPort instance
    		// Application can close itself
    	}
    	else
    	{
    		_serialPort.Close();
    	}
        ...
    }
    
    ...
    private bool Open()
    {
    	bool success = false;
    
    	Close();
    	
    	try
    	{
    		_serialPort = new SerialPort();
    		_serialPort.ErrorReceived += HandleErrorReceived;
    		_serialPort.PortName = _portName;
    		_serialPort.BaudRate = _baudRate;
    		_serialPort.StopBits = _stopBits;
    		_serialPort.Parity = _parity;
    		_serialPort.DataBits = (int)_dataBits;
    		_serialPort.ReadTimeout = 1000;
        
    		// We are not using serialPort.DataReceived event for receiving data since     this is not working under Linux/Mono.
    		// We use the readerTask instead (see below).
    		_serialPort.Open();
    		success = true;
    	}
    	catch (Exception e)
    	{
    		Close();
    	}
    
    	return success;
    }
