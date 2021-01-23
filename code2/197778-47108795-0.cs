    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(AMetaData))]
    public partial class A 
    {
        
    }
    public class AMetaData
    {
        [System.ComponentModel.DefaultValue(0)]
        public string Value { get; set; }
    }
