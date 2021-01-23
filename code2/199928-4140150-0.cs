    namespace MessageContractTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string action = null;
                XmlReader bodyReader = XmlReader.Create(new StringReader("<Example xmlns=\"http://tempuri.org/\"><Gold>109</Gold><Message>StackOverflow</Message></Example>"));
                Message msg = Message.CreateMessage(MessageVersion.Default, action, bodyReader);
                TypedMessageConverter converter = TypedMessageConverter.Create(typeof(Example), "http://tempuri.org/IFoo/BarOperation");
                Example example = (Example)converter.FromMessage(msg);
            }
        }
    
    
        [MessageContract]
        public class Example
        {
            [MessageHeader]
            public string Hello;
    
            [MessageHeader]
            public double Value;
    
            [MessageBodyMember]
            public int Gold;
    
            [MessageBodyMember]
            public string Message;
        }
    }
