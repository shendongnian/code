    public class ClassThatSendsMessages
    {
        private readonly IBus _bus;
        public ClassThatSendsMessages(IBus bus /*, ... */)
        {
            _bus = bus;
            /* ... */
        }
        public void CodeThatSendsMessage()
        {
            /* ... */
            _bus.Send<IMyMessage>(mm => mm.Property1 = "123");
            /* ... */
        }
    }
    public class ClassThatTestsClassThatSendsMessages
    {
        public void CallCodeThatSendsMessage()
        {
            //Mock IBus object here
            var objectToTest = new ClassThatSendsMessages(mockedIBus /*, ... */)
            objectToTest.CodeThatSendsMessage();
            //Verify that IBus mock's Send() method was called
        }
    }
