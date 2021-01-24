    public class DynamicsConnector : IDynamicsConnector
    {
        private readonly IOptions<DynamicsConnectorOptions> options { get; set; }
        public DynamicsConnector(IOptions<DynamicsConnectorOptions> options)
        {
           this.options = options;
        }
    } 
