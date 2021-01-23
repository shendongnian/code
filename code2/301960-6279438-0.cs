    //Sender
    byte[] bt = Encoding.UTF8.GetBytes("ş");
    serialport.write(bt);
    
    //Receiver
    byte[4] bt; //Unicode characters could be up to 4 bytes.
    SerialPort.Read(bt, 0, 4);
    string str = Encoding.UTF8.GetString(bt);
