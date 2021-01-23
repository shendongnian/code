          //strHostName is Machine name/IP from which you have to get queue
          //MSMQManagement present in COM library which is present at "C:\Program Files (x86)\Microsoft SDKs\Windows"
          PrivateQueueList =  MessageQueue.GetPrivateQueuesByMachine(strHostName);
          int count = PrivateQueueList.Count();
          MSMQManagement QueueManagement = new MSMQManagement[count];
          MSMQManagement msmq = null;      
          int index = 0;
          foreach(var queue in PrivateQueueList)
          {
               msmq = new MSMQManagement();          
               object machine = queue.MachineName;
               object path = null;
               object formate=queue.FormatName;
               msmq.Init(ref machine, ref path,ref formate);
               QueueManagement[index] = msmq;                                
               index++;
          }
          foreach(var queue in QueueManagement)
          {
               int count= queue.MessageCount();
               Console.WriteLine(queue.QueueName+ " ="+ count);
          }
