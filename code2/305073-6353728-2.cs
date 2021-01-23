    protected override void InsertItem(int index, IAddress newItem)
    {
        if (!this.Any(x => x.AddressType != newItem.AddressType)
        {
            base.InsertItem(index, newItem);
        }
        else
        {
            // ... item does not match, do whatever is appropriate e.g. throw an exception
        }
    }
    protected override void SetItem(int index, IAddress newItem)
    {
        ... etc ...
    }
