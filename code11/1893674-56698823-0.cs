    void BluetoothClientConnectCallback(IAsyncResult result)
    {
      BluetoothClient client = (BluetoothClient)result.AsyncState;
      Stream stream;
    
      try
      {
        client.EndConnect(result);
        stream = client.GetStream();
        stream.ReadTimeout = 1000;
        while (true)
        {
          while (!ready) ;
          message = Encoding.ASCII.GetBytes("{");
          stream.Write(message, 0, 1);
          ready = false;
        }
      }
    
      catch (System.Net.Sockets.SocketException)
      {
        MessageBox.Show("Unable to connect to device!", "Error",
        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
      }
      catch (InvalidOperationException ex) 
      { 
         MessageBox.Show("Invalid operation exception!", "Error",
         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
      }
      catch (Exception ex) 
      {
         MessageBox.Show("Exception thrown!", "Error",
         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
      }
    }
