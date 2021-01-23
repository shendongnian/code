    using MessageQueue = System.Messaging.MessageQueue;
    //...
    void CreateQueue(string qname) {
       if (!MessageQueue.Exists(qname)) MessageQueue.Create(qname);
    }
