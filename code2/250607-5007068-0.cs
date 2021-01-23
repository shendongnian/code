    [MetadataType(typeof(TestMD))]
    public partial class Test
    {
    }
    
    public class TestMD
    {
        [ScriptIgnore]
        public object Parent { get; set; }
    }
