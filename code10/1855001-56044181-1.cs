    private static async Task ProcessMessagesAsync(Message message, CancellationToken token)
    {
       bool result;
       try
       {
         var receivedMessageTrasactionId = Convert.ToInt64(Encoding.UTF8.GetString(message.Body));
    
         result = await DataCleanse.PerformDataCleanse(receivedMessageTrasactionId);                                                           
        }
        catch (Exception ex)
        {
          Log4NetErrorLogger(ex);
          throw ex;
        }
    
    }
