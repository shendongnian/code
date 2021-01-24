    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApp16
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("User IDs 1, 2, 3");
                ProcessMessages(GetTestMessages(1, 2, 3), 4);
    
                Console.WriteLine("User IDs empty");
                ProcessMessages(GetTestMessages(), 4);
    
                Console.WriteLine("User IDs 1, 2, 3, 4, 5, 6, 7, 8, 9, 10");
                ProcessMessages(GetTestMessages(1, 2, 3, 4, 5, 6, 7, 8, 9, 10), 4);
    
                Console.WriteLine("User IDs 2, 2, 2, 1, 1, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 6, 7, 8, 9, 10");
                ProcessMessages(GetTestMessages(2, 2, 2, 1, 1, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 6, 7, 8, 9, 10), 4);
    
                Console.ReadLine();
            }
    
            private static IEnumerable<Message> GetTestMessages(params int[] userIds)
            {
                int i = 1;
                foreach (var userId in userIds)
                    yield return new Message { MessageId = i++, UserId = userId };
            }
    
            private class Message
            {
                public int MessageId { get; set; }
                public int UserId { get; set; }
                //... Real message properties
            }
    
            private static void ProcessMessages(IEnumerable<Message> incomingMessages, int nThreads)
            {
                var tasks = GetPartitionedMessages(incomingMessages, nThreads)
                             .Select((messages, i) => Task.Run(() => DoMessageBusinessLogic(messages, i)))
                             .ToArray();
                Task.WaitAll(tasks);
            }
    
            private static void DoMessageBusinessLogic(IEnumerable<Message> messages, int threadIdx)
            {
                foreach (var message in messages)
                    Console.WriteLine($"Thread ID: {threadIdx}, MsgId: {message.MessageId}, UserId: {message.UserId}");
            }
    
            private static IEnumerable<IEnumerable<Message>> GetPartitionedMessages(IEnumerable<Message> messages, int nPartitions)
            {
                var orderedMessages = messages.OrderBy(x => x.UserId).ThenBy(x => x.MessageId).ToList();
                int? lastUserId = null;
                int maxPartitionSize = (int)Math.Ceiling(orderedMessages.Count / (double)nPartitions);
                var partitions = new List<List<Message>>();
                List<Message> currentPartition = null;
    
                foreach (var message in orderedMessages)
                {
                    if (lastUserId == message.UserId)
                    {
                        currentPartition.Add(message);
                    }
                    else
                    {
                        lastUserId = message.UserId;
                        if (currentPartition == null || currentPartition.Count >= maxPartitionSize)
                        {
                            currentPartition = new List<Message>();
                            partitions.Add(currentPartition);
                        }
    
                        currentPartition.Add(message);
                    }
                }
    
                return partitions;
            }
        }
    }
