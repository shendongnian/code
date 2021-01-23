    public override object GetItemAt(int index)
    {
        object rc = base.GetItemAt(index);
        // do something
        int internalIndex = -1;
        IList sourceCollection = SourceCollection as IList;
        if (sourceCollection != null)
        {
            internalIndex = sourceCollection.IndexOf(rc);
        }
        else
        {
            // See
            // http://stackoverflow.com/questions/2718139
        }
        return rc;
    }
