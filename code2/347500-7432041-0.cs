    lock (_subscribersSync)
             foreach (var chatter in subscribers)
             {
                     Logger.Log.DebugFormat("putting all users to {0}", subscribers.Key.Name);
                     Thread th = new Thread(PublishAllUserMessage);
                     th.Start(new MessageData() { Message = "", Subscriber = chatter.Key};
             }
    
    void PublishAllUserMessage(object messageData)
    {
            MessageData md = (MessageData)messageData;
            try
            {
                    md.Subscriber.NotifyEvent(...event parameters here ...);
            }
            catch (Exception ex)
            {
                    Logger.Log.Error(string.Format("failed to publish message to '{0}'", md.Subscriber.Name), ex);
                    KickOff(md.Subscriber);
            }
    }
    object _subscribersSync = new object();
    void KickOff(IEventSubscriber p)
    {
            lock (_subscribersSync)
            {
                    subscribers.Remove(p);
                    Logger.Log.WarnFormat("'{0}' kicked off", p.Name);
            }
    }
     public class MessageData
     {
             public string Message;
             public IEventSubscriber Subscriber;
    }
