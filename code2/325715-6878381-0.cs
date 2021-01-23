    public class WebDefinition
    {
        public WebDefinition(){} // for XmlSerializer
        public string Definition { get; set; }
        public string URL { get; set; }
        public WebDefinition(string def, string url)
        {
           Definition = def;
           URL = url;
        }
        public override string ToString() { return this.Definition; }
    }
 
