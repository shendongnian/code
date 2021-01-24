        class Program
        {
            static void Main(string[] args)
            {
                var encoding = new MtomMessageEncoderBindingElement(new TextMessageEncodingBindingElement());
                var transport = new HttpTransportBindingElement();
                transport.TransferMode = TransferMode.Streamed;
                var binding = new CustomBinding(encoding, transport);
                EndpointAddress endpoint = new EndpointAddress("http://vabqia969vm:21011");
                ChannelFactory<IService> channelFactory = new ChannelFactory<IService>(binding, endpoint);
                var webService = channelFactory.CreateChannel();
                Console.WriteLine(webService.Test());
            }
        }
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string Test();
    
    }
