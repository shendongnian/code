     public async Task SendMessage(object payload)
            {
                try
                {                
                    _queueClient = new QueueClient("Endpoint=sb://Subscription.servicebus.windows.net/;SharedAccessKeyName=DeviceTestQueueListenAccessKey;SharedAccessKey=hjklgtfapinznyx2gSnPqngQgIa9p7AxeihLoBz8+Sc=;EntityPath=devicetestqueue", QUEUE_NAME);
                    string data = JsonConvert.SerializeObject(payload);
                    Message message = new Message(Encoding.UTF8.GetBytes(data));
    
                    await _queueClient.SendAsync(message);
                }
                catch (Exception ex)
                {
                    throw;
                }
    
            }
