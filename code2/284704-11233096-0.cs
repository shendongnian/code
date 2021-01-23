     public void SendMessage()
            {
    	         MessageQueue myQueue = new MessageQueue(".\\QUEUE");
                 byte[] msg = new byte[2];
                 msg[0] = 29;               
                 // Send the array to the queue.
                    Message msg1 = new Message();
                    msg1.BodyStream = new MemoryStream(msg);
                    messageQueue.Send(msg1);                
            }
     public void ReceiveMessage()
            {
     	          MessageQueue myQueue = new MessageQueue(".\\QUEUE");               
    		Message myMessage =myQueue.Receive();
                    byte[] msg = ReadFully(myMessage.BodyStream);
            }
    
     public static byte[] ReadFully(Stream input)
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
