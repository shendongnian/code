    // POST api/values
    public HttpStatusCode Post([FromBody] List<CallbackEvent> callback)
    {
         foreach(var message in callback)
         {
            recCallback.Add(new tblCallback { Type = response, MessageID = 
                 message.Message.Id, Description = message.Description, MessageTo = 
                 message.To, SegmentCount = message.Message.SegmentCount });            
         }
         callbacks.SaveChanges();  // <-- Not sure of the context for this, but appears to be a dbContext and should be saved when done with List<T>
     }
