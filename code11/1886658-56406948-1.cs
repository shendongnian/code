    public async Task StarBrokerAsync()
    {
        // Start broker ...
        MqttServer.ApplicationMessageReceivedHandler = new MessageHandler();
    }
