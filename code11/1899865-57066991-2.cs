    [Fact]
    public void TopicPubSub()
    {
    	using (var pub = new XPublisherSocket())
    	using (var sub = new XPublisherSocket())
    	{
    		var port = pub.BindRandomPort("tcp://127.0.0.1");
    		sub.Connect("tcp://127.0.0.1:" + port);
    		sub.SendFrame(new byte[] { 1, (byte)'A' });
    
    		// let the subscriber connect to the publisher before sending a message
    		Thread.Sleep(500);
    
    		var msg = pub.ReceiveFrameBytes();
    
           
