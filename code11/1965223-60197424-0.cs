    objClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(ReceivedMessage);
  
    string[] strTopics = { "test/log", "test/log2" };
    MqttClientSubscribeOptions objSubOptions = new MqttClientSubscribeOptions();
    List<TopicFilter> objTopics = new List<TopicFilter>();
    foreach(string strTopic in strTopics)
    {
        TopicFilter objAdd = new TopicFilter();
        objAdd.Topic = strTopic;
        objTopics.Add(objAdd);
    }
     objSubOptions.TopicFilters = objTopics;
     objClient.ConnectAsync(objOptions, CancellationToken.None).Wait();
     objClient.SubscribeAsync(objSubOptions); //!!!!subscribe goes here!!!!
