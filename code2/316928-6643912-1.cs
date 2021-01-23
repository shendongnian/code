    partial class Fruit
    {
        public class FruitCollection : Collection<Fruit>
        {
            private readonly Fruit _parent;
            public FruitCollection(Fruit parent)
            {
                _parent = parent;
            }
            protected override void InsertItem(int index, Fruit item)
            {
                // item already has a parent?
                if (item._parent != null)
                {
                    // remove it from previous parent
                    item._parent._children.Remove(item);
                }
                // set the new parent
                item._parent = _parent;
                base.InsertItem(index, item);
            }
            // other methods should be overriden in a similar way
        }
    }
