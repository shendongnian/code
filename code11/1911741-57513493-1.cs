     public class ContentElement : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public int PageId { get; set; }
        public string LanguageCode { get; set; }
        public int ContentId { get; set; }
        public string PageName { get; set; }
        public string Content { get; set; }
        public int? DisplayOrder { get; set; }
        public byte[] Image { get; set; } //not sure what type this should be
        public string ContentType { get; set; }
    }
    
