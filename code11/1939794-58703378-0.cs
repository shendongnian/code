    class EGTenantCreated
    {
        [JsonProperty]
        internal string id { get; set; }
        [JsonProperty]
        internal string subject { get; set; }
        [JsonProperty]
        internal EGData data { get; set; }
        [JsonProperty]
        internal string eventType { get; set; }
        [JsonProperty]
        internal string eventTime { get; set; }
        [JsonProperty]
        internal string dataVersion { get; set; }
        [JsonProperty]
        internal string metadataVersion { get; set; }
        [JsonProperty]
        internal string topic { get; set; }
    }
    class EGData
    {
        [JsonProperty]
        internal string TenantId { get; set; }
        [JsonProperty]
        internal string TenantName { get; set; }
        [JsonProperty]
        internal string AdministratorEmail { get; set; }
        [JsonProperty]
        internal string ProductId { get; set; }
        [JsonProperty]
        internal string PackageInstanceId { get; set; }
        [JsonProperty]
        internal string CorrelationId { get; set; }
    }
