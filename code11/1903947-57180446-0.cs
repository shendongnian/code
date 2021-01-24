       using System;
    using System.Messaging;
    using System.Data.SqlClient;
    using System.Data;
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;
    
    namespace NeuroskyListener
    {
        class Program
        {
            public static bool isRunning;
            private static MessageQueue messageQueue;
            
            public static void Main(string[] args)
            {
                InitializeQueue();
                Console.ReadLine();
            }
    
            private static void InitializeQueue()
            {
                string queuePath = @".\Private$\eegNew";
    
                if (!MessageQueue.Exists(queuePath))
                {
                    messageQueue = MessageQueue.Create(queuePath);
                }
                else
                {
                    messageQueue = new MessageQueue(queuePath);
                }
                isRunning = true;
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(string) });
                messageQueue.ReceiveCompleted += OnReceiveCompleted;
                messageQueue.BeginReceive();
            }
    
            private static void OnReceiveCompleted(object source, ReceiveCompletedEventArgs asyncResult)
            {
                try
                {   
                    MessageQueue mq =  (MessageQueue)source;
    
                    if (mq != null)
                    {
                        try
                        {
                            System.Messaging.Message message = null;
                            try
                            {
                                message = mq.EndReceive(asyncResult.AsyncResult);
                                BinaryReader reader = new BinaryReader(message.BodyStream);
    
                                int count = (int)message.BodyStream.Length;
    
                                byte[] bytes = reader.ReadBytes(count);
    
           
                               string bodyString = Encoding.UTF8.GetString(bytes);
                                eegPayload lst = JsonConvert.DeserializeObject<eegPayload>(bodyString);
    
                            }
                            catch (Exception ex)
                            {
                               // LogMessage(ex.Message);
                            }
                            if (message != null)
                            {
                                //Payload payload = message.Body as Payload;
    
                                Console.WriteLine(message.Body);
    
                                //if (payload != null)
                                //{
                                //    receivedCounter++;
                                //    if ((receivedCounter % 10000) == 0)
                                //    {
                                //        string messageText = string.Format("Received {0} messages", receivedCounter);
                                //        LogMessage(messageText);
                                //    }
                                //}
                            }
                        }
                        finally
                        {
                            if (isRunning)
                            {
                                mq.BeginReceive();
                            }
                        }
                    }
                    return;
                }
                catch (Exception exc)
                {
                    //LogMessage(exc.Message);
                }
            }
        }
    }
 
