     MQQueueManager mqQMgr=null;
    
       Hashtable props = new Hashtable();
    
    props.Add(MQC.HOST_NAME_PROPERTY, "HostNameOrIP");
    
       props.Add(MQC.CHANNEL_PROPERTY, "ChannelName");
    
       props.Add(MQC.PORT_PROPERTY, 1414); // port number
    
       props.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
    
       MQQueue mqQueue = null;
    
       try
    
       {
    
          mqQMgr = new  MQQueueManager("QueueManagerName", props);
    
          mqQueue = mqQMgr.AccessQueue(
                   QueueName,
                   MQC.MQOO_OUTPUT                   // open queue for output
                   + MQC.MQOO_FAIL_IF_QUIESCING);   // but not if MQM stopping
       }
    
       catch (MQException mqe1)
    
       {
    
       }
