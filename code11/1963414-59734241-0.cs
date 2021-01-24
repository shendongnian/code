    private bool ConnectAndSendMessage(String server, Int32 port, String message)
        {
            try
            {
                // Create a TcpClient.
                TcpClient client = new TcpClient(server, port);
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream(); 
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
               
                // Buffer to store the response bytes receiver from the running server.
                data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                // Close everything.
                stream.Close();
                client.Close(); return true;
            }
            catch (ArgumentNullException e)
            {
                _txtStyling.WriteCustomLine(string.Format("ArgumentNullException: {0} \n\n", e.Message), 14, false, false, Brushes.Red); return false;
            }
            catch (SocketException e)
            {
                _txtStyling.WriteCustomLine(string.Format("SocketException: {0} \n\n", e.Message), 14, false, false, Brushes.Red); return false;
            }
        }
