    [ParseChildren(true, "text")]
    public class OverrideContent
    {
        public string targetId { get; set; }
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        public string text { get; set; }
    }
