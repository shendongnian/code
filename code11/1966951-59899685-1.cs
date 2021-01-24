    [ModelBinder(typeof(NetworkModelBinder))]
    public class Network
    {
        public string Network { get; set; }
        public string Cidr { get; set; }
        public string TenantId { get; set; }
    }
