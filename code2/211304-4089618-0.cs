    // actually write it using properties, information hiding etc instead...
    public class Document {
        public ICollection<Link> Links;
    }
    public class Link {
        public ICollection<Document> Documents;
        // this can be on Document as well, depending on what semantics you want...
        public void Add(Document d) {
            Documents.Add(d);
            d.Links.Add(this);
    }
