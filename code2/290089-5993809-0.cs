    //data recieved event handler
    private void dataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string tmp;
            tmp = sp.ReadExisting();
            //cut out any unnecessary characters
            tmp = tmp.Replace("\n", "");
            tmp = tmp.Replace(",", "\r");
            tmp = tmp.Replace(" ", "");
            lock (this)
            {
                //put all received data into the read buffer
                readBuffer += tmp;
                waitHandle.Set(); // <-- tell parseBuffer that new data is available
           }
    }
