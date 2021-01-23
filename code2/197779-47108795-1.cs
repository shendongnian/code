    using System.ComponentModel.DataAnnotations;
    
    // your auto-generated partial class
    public partial class A 
    {
        public string MyProp { get; set; }
    }
    [MetadataType(typeof(AMetaData))]
    public partial class A 
    {
        
    }
    public class AMetaData
    {
        [System.ComponentModel.DefaultValue(0)]
        public string MyProp { get; set; }
    }
