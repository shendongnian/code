    [MetadataType(typeof(PMetaData))]
    public partial class P
    {
        public class PMetaData
        {
            [UIHint("CClassDropDown")] 
            [DataType(DataType.Text)]
            public object C { get; set; }
        }
    }
