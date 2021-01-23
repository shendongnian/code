    [MetadataTypeAttribute(typeof(Part_Stock.Metadata))]
    public partial class Part_Stock
    {
        internal sealed class Metadata
        {
            // Metadata classes are not meant to be instantiated.
            private Metadata()
            {
            }
            [Include]
            public EntityCollection<Stock_Table> Stock_Table { get; set; }
        }
    }
