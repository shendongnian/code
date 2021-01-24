    public void ReceiveAndSaveData(MessageQueue queue, MsmqDbContext context)
    {
        var message = new Message();
        MessageQueueTransaction tx;
        try
        {
            using (tx = new MessageQueueTransaction())
            {
                tx.Begin();
                message = queue.Receive(tx);
                var bodyReader = new StreamReader(message.BodyStream);
                var jsonBody = bodyReader.ReadToEnd();
                var messageData = JsonConvert.DeserializeObject<QueueMessage>(jsonBody);
                /*THERE IS SOME DATA PROCESSING*/
            }
        }
        catch (JsonSerializationException e)
        {
            Logger.WriteError(new LogDetail("Error occured during deserializing incoming data.", e, message.Id));
            tx.RemoveCurrent(); //alternatively, pass in message here. 
            //tx.RemoveCurrent(message);
        }
        catch (Exception e)
        {
            Logger.WriteError(new LogDetail("Error occured during saving data to database", e, message.Id));
        }
        finally
        {
            tx.Commit();
        }
    }
