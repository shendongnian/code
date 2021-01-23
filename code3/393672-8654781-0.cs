    _sp = new SerialPort(Conf.Value("ExternalClockPort"), int.Parse(Conf.Value("ExternalClockBaud")), Parity.None, 8, StopBits.Two);
    _sp.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
    _sp.Open();
 
    private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        int totalBytes = _sp.BytesToRead;
        byte[] buffer = new byte[totalBytes];
        _sp.Read(buffer, 0, totalBytes);
    }
