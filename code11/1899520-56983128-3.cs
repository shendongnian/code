    public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
    
            {
    
                header_value = // Read the value from the properites variable
                if (header_value matches) {
                    // Reject or delete the message
                    _channel.BasicReject(deliveryTag, false);
                }
                else {
                    // Accept the message and do your processing
                    _channel.BasicAck(deliveryTag, false);
                }
                
            }
