    static async Task ReceiveMessagesAsync(Message message, CancellationToken token)  
    {  
        try  
        {  
            Console.WriteLine($"Received message: {Encoding.UTF8.GetString(message.Body)}");  
            int i = 0;  
            i=i / Convert.ToInt32(message);  
            await queueClient.CompleteAsync(message.SystemProperties.LockToken);  
         }  
         catch(Exception ex)  
         {  
             await queueClient.AbandonAsync(message.SystemProperties.LockToken);  
         }  
     }  
 
