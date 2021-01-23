    AutoResetEvent autoEvent = (AutoResetEvent)stateObject;
    autoEvent.WaitOne();
    Trace.Write("Starting ProcessQueue");
    SmtpClient smtp = new SmtpClient("winprev-01");
    foreach (MessageQueue message in AllUnprocessed){
