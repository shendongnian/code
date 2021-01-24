    public class MessageHandler: IMqttApplicationMessageReceivedHandler
    {
        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            if (eventArgs.ApplicationMessage.Topic == "name_of_desired_topic")
            {
                // Handle event
            }
        }
    }
