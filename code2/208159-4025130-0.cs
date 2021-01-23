    // This class keep the copy of the message when arrived
    public class OneMessageIn
    {
        public MyMessage Message
    }
    
    void SendAndWait() 
    { 
        AutoResetEvent waitForAnswer = new AutoResetEvent(false); 
        int msgReferenceNumber = 1; 
        OneMenssageIn msgBox = new OneMessageIn(); 
     
        // Register to wait for answer to the message with the number = msgReferenceNumber 
        RegisterToWait(msgNumber, waitForAnswer, ref msgBox); 
        // Send the request to the server, with the reference number. 
        SendRequest(msgReferenceNumber); 
     
        // Wait until the server send my answer 
        waitForAnswer.WaitOne(); 
     
        // Now I have my answer!!!
        MessageBox.Show(msgBox.Message.Text); 
    }
    
    public class WhoWait     
    {     
        public int RefNumMsg;     
        public AutoResetEvent WaitForAnswer;     
        public OneMessageIn MessageWithAnswer;     
    }     
    // In this Dicctionary I save who wait for answers.     
    private Dictionary<int, WhoWait> Waiting = new Dictionary<WhoWait>();     
    
    // I'm not sure if ref is necesary, but with it works. I don't try without ref.    
    void RegisterToWait(int msgRefNumber, AutoResetEvent waitForAnswer, ref OneMessageIn msgBox)    
    {    
      WhoWait w = new WhoWait();    
      w.RefNumMsg = msgRefNumber;    
      w.WaitForAnswer = waitForAnswer;    
      w.MessageWithAnswer = msgBox;    
        
      Waiting.Add(msgRefNumber, w);    
    }
    
    void OnRecieve()       
    {       
         // Get data from server       
         MyMessage msg = GetMessageData();       
           
         // Search for someone waiting for this answer       
         WhoWait w = Wainting[msg.RefNum];       
           
         // Set the response message       
         w.MessageWithAnswer.Message = msg;       
           
         // Warn to the main thread. Message with their answer arrive       
         w.WaitForAnswer.Set();       
    } 
