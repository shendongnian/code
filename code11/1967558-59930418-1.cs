    public void ReceiveAndSaveData(MessageQueue queue, MsmqDbContext context)
    {
        bool exceptionOccurred = false;
        var message = new Message();
        MessageQueueTransaction tx;
        try
        {
            exceptionOccurred = false;
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
            tx.Abort(); //Rolls back the pending internal transaction
            exceptionOccurred = true;
        }
        catch (Exception e)
        {
            Logger.WriteError(new LogDetail("Error occured during saving data to database", e, message.Id));
             exceptionOccurred = true;
        }
        finally
        {
            if(!exceptionOccurred)
                tx.Commit();
        }
    }
