    public class ClassUsingChannelWrapper
    {
        IClientChannelWrapper _wrapper;
        public ClassUsingChannelWrapper(IClientChannelWrapper wrapper)
        {
            _wrapper = wrapper;
        }
    
        public void TheClientChannelConsumerMethod()
        {
            IInnerChannel theChannel = _wrapper.GetTheInnerChannelMethod();
            var result = theChannel.TheInnerChannelMethod();
            Console.WriteLine(result);
        }
    }
