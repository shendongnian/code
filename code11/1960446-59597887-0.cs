    public class Source
    {
        public string TemplateSource { get; set; }
    }
    public class RootObject
    {
        public List<List<Template>> Templates { get; set; }
        public Source Source { get; set; }
    }
    public class Template
    {
        public string Id { get; set; }
        public string FileName { get; set; }
    }
