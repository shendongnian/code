    public class InnerChannelImplementation : IInnerChannel
    {
        public InnerChannelImplementation()
        {
        }
    
        public string TheInnerChannelMethod()
        {
            var result = "This is coming from innser channel.";
            Console.WriteLine(result);
            return result;
    
        }
    }
