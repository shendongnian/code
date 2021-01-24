    var Mutex mutex = new Mutex();
    consumer.Received += (model, ea) =>
    {
    try
    {
        DRModel drModel = JsonConvert.DeserializeObject<DRModel>(Encoding.UTF8.GetString(ea.Body));
        RMQReturnType type = ProcessSubmitSMS(drModel);
        if (type == RMQReturnType.ACK)
            channel.BasicAck(ea.DeliveryTag, false);
        else
        { 
            channel.BasicNack(ea.DeliveryTag, false, true);
            mutex.WaitOne(); // this is where you need to sleep
            Thread.Sleep(300000); // <=== SLEEP
        }
    }
    catch (Exception ex)
    {
        channel.BasicNack(ea.DeliveryTag, false, true);
        WriteLog(ControlChoice.ListError, "Exception: " + ex.Message + " | Stack Trace: " + ex.StackTrace.ToString() + " | [Consumer Event]");
       mutex.ReleaseMutex();  // this is where you release, if something goes wrong
    }
    };
