    public interface IMQQueueManager 
    {
    	void Send(string message, MQManMock obj);
    }
    
    public interface ConcreteMQQueueManager : IMQQueueManager
    {
    	public void Send(string message, MQManMock obj)
    	{
    		//create a mock MQ manager
                var MQManMock = new MQQueueManager();
    
                //test by calling the send method
                MyMQhandler.MQSender mqsender = new MyMQhandler.MQSender();
                //error happens when trying to access the moq object here
                mqsender.Send("test message", MQManMock.Object); 
    	}
    }
