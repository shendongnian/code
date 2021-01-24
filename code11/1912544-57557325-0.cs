    private async void BtnSubscrbe_Click(object sender, RoutedEventArgs e)
    {
        client.MessageStream.Subscribe(msg =>
        {
            string topic = msg.Topic;
            byte[] payload = msg.Payload;
            //deserialize and do something...
        });
        await client.SubscribeAsync("test1", MqttQualityOfService.ExactlyOnce);
    }
