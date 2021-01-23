    using System;
    using System.Net;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure.StorageClient.Protocol;
    class Program
    {
        static void Main(string[] args)
        {
            var q = CloudStorageAccount.Parse("UseDevelopmentStorage=true").CreateCloudQueueClient().GetQueueReference("testqueue");
            q.CreateIfNotExist();
            var req = QueueRequest.PutMessage(new Uri(q.Uri, q.Name + "/messages"), 30, null);
            var body = QueueRequest.GenerateMessageRequestBody("hello world");
            req.ContentLength = body.Length;
            q.ServiceClient.Credentials.SignRequest(req);
            using (var stream = req.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
                stream.Close();
            }
            req.GetResponse();
            req = QueueRequest.GetMessages(new Uri(q.Uri, q.Name + "/messages"), 30, 32, null);
            q.ServiceClient.Credentials.SignRequest(req);
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                using (var msgResponse = QueueResponse.GetMessages(response))
                {
                    foreach (var msg in msgResponse.Messages)
                    {
                        Console.WriteLine("MESSAGE: " + msg.Text);
                        q.DeleteMessage(msg.Id, msg.PopReceipt);
                    }
                }
            }
            q.Delete();
        }
    }
