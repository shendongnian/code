    public void DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
          var datareceived = serialport.ReadLine()
          // Do data processing here
           
          // Invoke delegate using dispatcher to update UI
    
    }
