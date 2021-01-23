    [MetadataType(typeof(TextMeta))] 
    public partial class Text {}
    
    public class TextMeta 
    {
        [Required(ErrorMessage="This is required!!!")]
        public string Title { get; set; } 
    }
