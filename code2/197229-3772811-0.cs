namespace OpenRastaApp
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType&lt;List&lt;Foo&gt;&gt;()
                    .AtUri("/foos")
                    .HandledBy&lt;FooHandler&gt;()
                    .AsJsonDataContract();
                ResourceSpace.Has.ResourcesOfType&lt;Foo&gt;()
                    .AtUri("/foos/{id}")
                    .HandledBy&lt;FooHandler&gt;()
                    .AsJsonDataContract();
            }
        }
    }
}
