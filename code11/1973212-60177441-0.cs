	string path = EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName);
	var receiver = new MessageReceiver(connectionString, path);
	var bytes = receiver.ReceiveAsync().Result.Body;
	string s = Encoding.UTF8.GetString(bytes);
	Console.WriteLine(s);
