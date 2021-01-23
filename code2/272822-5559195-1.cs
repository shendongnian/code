    using System.Messaging;
    //...
    void CreateQueue(string qname) {
       if (!MessageQueue.Exists(qname)) MessageQueue.Create(qname);
    }
