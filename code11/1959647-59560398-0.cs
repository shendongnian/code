    public class SMSBuilder {
        
         private string _phoneNumber;
         internal string _message
         public void SMSBuilder(string phoneNumber, string message) 
         {
            _phoneNumber = phoneNumber;
            _message = message;
         }
    
         public void SendSms()
         {
           //code that sends sms
         }
    }
