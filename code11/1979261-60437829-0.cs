        static void Main(string[] args)
        {
            var connectionString = "my-connection-string";
            var queueName = "test";
            QueueClient queueClient = new QueueClient(connectionString, queueName);
            Message msg1 = new Message()
            {
                Body = Encoding.UTF8.GetBytes("This message has ScheduledEnqueueTimeUtc property set. It will appear in queue after 2 minutes. Current date/time is: " + DateTime.Now),
                ScheduledEnqueueTimeUtc = DateTime.UtcNow.AddMinutes(2)
            };
            queueClient.SendAsync(msg1).GetAwaiter().GetResult();
            Message msg2 = new Message()
            {
                Body = Encoding.UTF8.GetBytes("This message is sent via ScheduleMessageAsync method. It will appear in queue after 2 minutes. Current date/time is: " + DateTime.Now)
            };
            queueClient.ScheduleMessageAsync(msg2, new DateTimeOffset(DateTime.UtcNow.AddMinutes(2))).GetAwaiter().GetResult();
            Console.ReadLine();
        }
