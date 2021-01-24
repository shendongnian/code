    public class ClientChannelWrapperImplementation : IClientChannelWrapper
    {
        public ClientChannelWrapperImplementation()
        {
        }
    
        public void DoSomething()
        {
            Console.WriteLine("The DoSomething Method!");
        }
    
        public IInnerChannel GetTheInnerChannelMethod()
        {
            InnerChannelImplementation imp = new InnerChannelImplementation();
            return imp;
        }
    }
