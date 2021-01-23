    namespace MyApp.BusinessObjects
    {
        [MetadataTypeAttribute(typeof(SomeClass.Metadata))]{
        public partial class SomeClass
        {
            internal sealed class Metadata
            {
                private Metadata()
                {
                }
    
                [Required]
                public string Name{ get; set; }
            }
        }
    }
