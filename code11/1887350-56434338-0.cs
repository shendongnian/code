    if (inspector != null)
    {
        object item = inspector.CurrentItem;
        if (item != null)
        {
           //blah
           Marshal.ReleaseComObject(item); 
        }
    }
