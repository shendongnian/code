    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus;
    
    namespace ConsoleApp2
    {
        class Program
        {
            const string ServiceBusConnectionString = "xxxxxx";
            const string QueueName = "xxx";
            static IQueueClient queueClient;
            public static async Task Main(string[] args)
            {
                queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
    
                RegisterOnMessageHandlerAndReceiveMessages();
    
                Console.ReadKey();
    
                await queueClient.CloseAsync();
            }
            static void RegisterOnMessageHandlerAndReceiveMessages()
            {
                var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
                {
                    MaxConcurrentCalls = 10,
                    AutoComplete = false
                };
                queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
            }
            static async Task ProcessMessagesAsync(Message message, CancellationToken token)
            {
                Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
                await queueClient.CompleteAsync(message.SystemProperties.LockToken);
            }
            static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
            {
                Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
                var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
                Console.WriteLine("Exception context for troubleshooting:");
                Console.WriteLine($"- Endpoint: {context.Endpoint}");
                Console.WriteLine($"- Entity Path: {context.EntityPath}");
                Console.WriteLine($"- Executing Action: {context.Action}");
                return Task.CompletedTask;
            }
        }
    }
