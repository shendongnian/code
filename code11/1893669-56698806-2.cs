    void BluetoothClientConnectCallback(IAsyncResult result)
    {
    	try
    	{
    		BluetoothClient client = (BluetoothClient)result.AsyncState;	
    		client.EndConnect(result);
    		using (var stream = client.GetStream())
    		{
    			stream.ReadTimeout = 1000;
    			while (true)
    			{
    				while (!ready) ;
    				message = Encoding.ASCII.GetBytes("{");
    				stream.Write(message, 0, 1);
    				ready = false;
    			}
    		}
    	}
    
    	catch (System.Net.Sockets.SocketException)
    	{
    		MessageBox.Show("Unable to connect to device!", "Error",
    				   MessageBoxButtons.OKCancel, MessageBoxIcon.Error);    
    	}
        catch (Exception ex)
        {
            //general exception catch, handle or ignore, but best is to log
        }
    }
