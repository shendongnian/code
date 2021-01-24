    using System;
    using Microsoft.Azure; 
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Queue;
    
    namespace ReceiveMessageFromAzureStorageQueue
    {
        class Program
        {
            static void Main(string[] args)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=0730bowmanwindow;AccountKey=lti/ThmF+mw9BebOacp9gVazIh76Q39ecikHSCkaTcGK5hmInspX+EkjzpNmvCPWsnvapWziHQHL+kKt2V+lZw==;EndpointSuffix=core.windows.net");
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference("111");
                CloudQueueMessage peekedMessage = queue.PeekMessage();
                while (peekedMessage!=null) {
                        System.Threading.Thread.Sleep(10);
                        CloudQueueMessage retrievedMessage = queue.GetMessage(TimeSpan.FromMilliseconds(10));
                        Console.WriteLine(retrievedMessage.AsString);
                        queue.DeleteMessage(retrievedMessage);
                }
                Console.WriteLine("Already Read.");
            }
        }
    }
