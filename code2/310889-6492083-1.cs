            string xmlstr = string.Empty;                
                
 
                try 
                { 
                    // Receive the message 
                    completeMessage = this.messageQueue.EndReceive(e.AsyncResult);                    
                    completeMessage.BodyStream.Read(bytes, 0, bytes.Length); 
 
                    System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding(); 
 
                    long len = completeMessage.BodyStream.Length; 
                    int intlen = Convert.ToInt32(len);                   
                    xmlstr = ascii.GetString(bytes, 0, intlen);                   
                } 
                catch (Exception ex0) 
                { 
                    //Error converting message to string                    
                } 
}
