    //call db
    //fill object
       //while filling object
         DateTime received = this.TimeReceived
         DateTime read = this.TimeRead          
         if (received == DateTime.MinValue)
         {  
             MessageStatus  = "Message Not Received";
         }
         else (read == DateTime.MinValue)
         {
             MessageStatus  = "Message Received";
         }
