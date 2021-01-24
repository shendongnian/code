    private DateTime _lastSeen = null;
    private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DateTime localNow = DateTime.Now;
            byte[] data = new byte[1024];
            int bytesRead;
            bytesRead = port.Read(data, 0, data.Length);
             // TODO magic number "1 second" to be replaced by Config-Value or Const
            if( _lastSeen == null || (localNow  - _lastSeen) < TimeSpan.FromSeconds(1)) 
            {
                koda = System.Text.Encoding.UTF8.GetString(data);
                MessageBox.Show(koda); // <-- I'd reconsider this, too.
            }
            // port.Close(); // Do not close the port here.         
            _lastSeen = localNow;
        }
