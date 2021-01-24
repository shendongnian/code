    public class ProviderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<AttributeViewModel> Attributes { get; set; }
    }
    public class AttributeViewModel
    {
        public string Guid { get; set; }
        public string Name { get; set; }
    }
