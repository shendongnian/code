    // Problematic, as there is a collection in here that gets refered to
    public ReceiptEntry FlatCopy() => this.MemberwiseClone() as ReceiptEntry;
    
    // Totally fine as we create a new collection
    public ReceiptEntry FlatCopy()
    {
        var copy = this.MemberwiseClone() as ReceiptEntry;
        copy.PicklistEntries = new ObservableCollection<PickListEntry>();
        copy.Id = 0;
        return copy;
    }
