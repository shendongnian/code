     public class PersonDetails
     {
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public DateTime DateTime { get; set; }
     }
    
         const string queueName = @".\private$\PersonQueue";
         public void GetMessageFromQueue(string queueName)
         {
          MessageQueue perosnMessageQueue = new MessageQueue(queueName);
         try
         {
         XmlMessageFormatter xmlMessageFormatter = new XmlMessageFormatter(new Type[] { 
                                   (typeof(PersonDetails)) });
          perosnMessageQueue.Formatter = xmlMessageFormatter;
          perosnMessageQueue.Refresh();
          for (int i = perosnMessageQueue.GetAllMessages().Count(); i !=0; i--)
          {
          var personDetailsFromQueue =
                             (PersonDetails)perosnMessageQueue.Receive
                             (MessageQueueTransactionType.Automatic).Body;
            Console.WriteLine("FistName : {0} \n LastName : {1} \n Date Time : 
             {2}",personDetailsFromQueue.FirstName, 
                  personDetailsFromQueue.LastName, 
                  personDetailsFromQueue.DateTime);`  
           }
