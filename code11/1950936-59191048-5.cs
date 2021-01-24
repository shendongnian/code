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
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("xxxxxx");
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference("xxx");
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
