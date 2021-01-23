    abstract class Visitor : IVisitor {
        public virtual void Visit(Document document) {
            ICollection<Block> container = document; // I dont like to use the 'as' keyword, if I only want to fool the compiler to pick another overload.
            this.Visit(container);
        }
        public virtual void Visit(Section section) {
            ICollection<Block> container = section;
            this.Visit(container);
        }
        public virtual void Visit(Paragraph paragraph) {
            ICollection<Inline> container = paragraph;
            this.Visit(container);
        }
        protected virtual void Visit(ICollection<Inline> container) { }
        protected virtual void Visit(ICollection<Block> container) { }
        protected virtual void Visit(ICollection<Element> container) { }
    }
