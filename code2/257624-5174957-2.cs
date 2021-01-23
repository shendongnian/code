    abstract class SearchVisitor : Visitor {
        protected override Visit(ICollection<Block> container) {
            this.AssignAll(container);
        }
        protected override Visit(ICollection<Inline> container) {
            this.AssignAll(container);
        }
        protected override Visit(ICollection<Element> container) {
            this.AssignAll(container);
        }
        private void AssignAll<TElement>(IEnumerable<TElement> container) {
            foreach (IVisitable element in container) {
                element.Assign(this);
            }
        }
    }
