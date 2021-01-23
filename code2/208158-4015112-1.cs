    void SendAndWait()
    {
        AutoResetEvent waitForAnswer = new AutoResetEvent(false);
        int msgReferenceNumber = 1;
        MyMessage msg;
    
        // Register to wait for answer to the message with the number = msgReferenceNumber
        RegisterToWait(msgNumber, waitForAnswer, receivedMessage => msg = receivedMessage);
    
        // Send the request to the server, with the reference number.
        SendRequest(msgReferenceNumber);
    
        // Wait until the server send my answer
        waitForAnswer.WaitOne();
    
        // Now I have my  answer. BUT I HAVE msg == null
        MessageBox.Show(msg.Text);
    }
    
    public class WhoWait
    {
        public int RefNumMsg;
        public AutoResetEvent WaitForAnswer;
        public Action<MyMessage> MessageSetter;
    }
    
    void RegisterToWait(int msgRefNumber, AutoResetEvent waitForAnswer, Action<MyMessage> msgSetter)
    {
      WhoWait w = new WhoWait();
      w.RefNumMsg = msgRefNumber;
      w.WaitForAnswer = waitForAnswer;
      w.MessageSetter = msgSetter;
    
      Waiting.Add(msgRefNumber, w);
    }
    
    
    void OnRecieve()
    {
         // Get data from server
         MyMessage msg = GetMessageData();
    
         // Search for someone waiting for this answer
         WhoWait w = Wainting[msg.RefNum];
    
         // Set the response message
         w.MessageSetter(msg);
    
         // Warn to the main thread. Message with their answer arrive
         w.WaitForAnswer.Set();
    }
