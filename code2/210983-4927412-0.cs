    [MetadataTypeAttribute(typeof(SP1_Result.SP1_ResultMetadata))]
    public partial class SP1_Result
    {
        internal sealed class SP1_ResultMetadata
        {
            [Key]
            public int MyId;  // Change MyId to the ID field of your SP_Result
        }
    } 
