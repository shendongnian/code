    private void ReceiveMessages()
		{
			
    		while (tcpClient.Connected) {
				try {
					
					var networkstream = tcpClient.GetStream();
					var header = new byte[4];
					networkstream.Read(header, 0, 4);
					
					int len = 0;
					// calculate length from header
					// Do reverse for BigEndian, for little endian remove
					Array.Reverse(header);
					len = BitConverter.ToInt32(header, 0);
					
					var message = new byte[len];
					networkstream.Read(message, 0, message.Length);
					
					// Process message
				
	            }
	            catch (Exception ex)
	            {
	               	Print(ex.Message);
					// Exit loop something went wrong
					break;
	            }
	        }
        
	    	Print("Receiver thread terminated.");
    		Reconnect();
		
		}
