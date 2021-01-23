    [XmlRoot(ElementName = "DispatchSettings", Namespace = "")]
    public sealed class DispatchSettings : IDispatchConfiguration
    {
        public Int32 DispatchProcessBatchSize { get; set; }
        public Boolean ServiceIsActive { get; set; }
        ...
    }
