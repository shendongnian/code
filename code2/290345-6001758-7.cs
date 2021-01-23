    private void ReceiveMessages()
            {
                // Receive the response from the server
                srReceiver = new StreamReader(tcpServer.GetStream());
                while (Connected)
                {
                    String con = srReceiver.ReadLine();
                    string StringMessage = HttpUtility.UrlDecode(con, System.Text.Encoding.UTF8);
                    
                    processMessage(StringMessage);
                    
                    
    
                }
            }
