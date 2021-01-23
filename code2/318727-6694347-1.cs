     class RowContentCollection : Collection<IRowContent>
        {
            bool containsSingleItem = false;
            protected override void InsertItem(int index, IRowContent item)
            {
                if (containsSingleItem)
                    throw new InvalidOperationException("Collection contains an item that doesnt allow other items.");
    
                containsSingleItem = !item.SupportsOtherChildren;
    
                base.InsertItem(index, item);
            }
    
            protected override void RemoveItem(int index)
            {
                if (!this[index].SupportsOtherChildren)
                    containsSingleItem = false;
    
                base.RemoveItem(index);
            }
        }
