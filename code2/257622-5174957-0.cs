    interface IVisitable {
        void Assign(IVisitor);
    }
    interface IVisitor {
        void Visit(Document document);
        void Visit(Section section);
        void Visit(Paragraph paragraph);
    }
    class Element : IVisitable {
        void IVisitable.Assign(IVisitor visitor) {
            this.Assign(visitor);
        }
        protected abstract void Assign(IVisitor visitor);
    }
    abstract class Block : Element { }
    abstract class Inline : Element { }
    abstract class BlockContainer<TElement> : Block, ICollection<TElement> { }
    abstract class ElementContainer<TElement> : Element, ICollection<TElement> { }
    abstract class InlineContainer<TElement> : Inline, ICollection<TElement> { }
    class Paragraph : BlockContainer<Inline> {
        protected override void Assign(IVisitor visitor) { visitor.Visit(this); }
    }
    class Section : BlockContainer<Block> {
        public string Title { get; set; }
        protected override void Assign(IVisitor visitor) { visitor.Visit(this); }
    }
    class Document : ElementContainer<Block> {
        protected override void Assign(IVisitor visitor) { visitor.Visit(this); }
    }
