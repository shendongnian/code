    private static void TestDispatchingMessage()
    {
    	var reader = XmlDictionaryReader.CreateBinaryReader(new FileStream(@"path\request_6c6fc02f-45a7-4049-9bab-d6f2fff5cb2d.xml", FileMode.Open), XmlDictionaryReaderQuotas.Max);
    	var message = Message.CreateMessage(reader, int.MaxValue, MessageVersion.Soap11);
    	message.Headers.To = new System.Uri(@"url");
    
    
    	BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None)
    	{
    		MessageEncoding = WSMessageEncoding.Mtom,
    		MaxReceivedMessageSize = int.MaxValue,
    		SendTimeout = new TimeSpan(1, 0, 0),
    		ReaderQuotas = { MaxStringContentLength = int.MaxValue, MaxArrayLength = int.MaxValue, MaxDepth = int.MaxValue }
    	};
    
    	var cf = new ChannelFactory<IRequestChannel>(binding, new EndpointAddress(@"url"));
    
    	foreach (OperationDescription op in cf.Endpoint.Contract.Operations)
    	{
    		op.Behaviors.Remove<DataContractSerializerOperationBehavior>();
    		op.Behaviors.Add(new ProtoBehaviorAttribute());
    	}
    
    	cf.Open();
    	var channel = cf.CreateChannel();
    	channel.Open();
    
    	var result = channel.Request(message);
    
    	Console.WriteLine(result);
    
    	channel.Close();
    	cf.Close();
    }
