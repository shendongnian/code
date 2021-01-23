    class HtmlMarkupRenderer : SearchVisitor {
        private readonly XmlWriter writer;
        private int sectionDepth = 0;
        public HtmlMarkupRenderer(TextWriter textWriter) {
            this.writer = XmlWriter.Create(textWriter, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Fragment });
        public override void Visit(Section section) {
            this.sectionDepth++;
            string headingElement = String.Concat("h", Math.Max(this.sectionDepth, 6));
            this.writer.WriteElementString(headingElement, section.Title);
            // The base implementation will assign this visitor to all childs of section.
            base.Visit(section);
            this.sectionDepth--;
        }
        public override void Visit(Paragraph paragraph) {
            this.writer.WriteStartElement("p");
            base.Visit(paragraph);
            this.writer.WriteEndElement();
        }
    }
