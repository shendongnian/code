    public int Compare(SomeClass x, SomeClass y)
    {
        var compared = x.SomeSortableKeyTypeField.CompareTo(y.SomeSortableKeyTypeField);
        if (compared != 0)
            return compared;
        // to allow duplicates
        return x.GetHashCode().CompareTo(y.GetHashCode());
    }
