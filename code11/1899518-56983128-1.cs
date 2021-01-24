    public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
    
            {
    
                // Read the value from the properites variable and do your processing
    
                _channel.BasicAck(deliveryTag, false);
    
            }
