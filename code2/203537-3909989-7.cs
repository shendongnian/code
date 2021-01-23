    public class ClassThatTestsClassThatSendsMessages
    {
        public void CallCodeThatSendsMessage()
        {
        Action<IMyMessage> messageAction = null;
        //Mock IBus object here
        mockedIBus.Setup(b => b.Send(Args.IsAny<Action<IMyMessage>>()))
            .Callback((Action<IMyMessage> a) => messageAction = a);
        var myMessage = Test.CreateInstance<IMyMessage>();
        var objectToTest = new ClassThatSendsMessages(mockedIBus /*, ... */)
        //Run the code that sends the message
        objectToTest.CodeThatSendsMessage();
        //Run the code that populates the message
        messageAction(myMessage);
        //Verify expectations on Setups
        //Verify the message contents;
        }
    }
