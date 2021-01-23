    public interface IServiceChannelFactoryFactory //I'm terrible at naming
    {
        //This is much like the generated concrete class when you use "Add Service Reference"
        //Except there is no method with an empty parameter
        ChannelFactory<T> GetService<T>(string endpointName);
    }
