    public class Document
    {
        private List<DocumentSection> sections = new List<DocumentSection>();
        public void AddSection(DocumentSection section) {
            sections.Add(section);
        }
        public IEnumerable<DocumentSection> Sections {
            get { return sections; }
        }
    }
