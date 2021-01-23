    private void AddFilter()
    {
        CollViewSource.Filter -= new FilterEventHandler(Filter);
        CollViewSource.Filter += new FilterEventHandler(Filter);  
    
    }
    
    private void Filter(object sender, FilterEventArgs e)
    {
        // see Notes on Filter Methods:
        var src = e.Item as YourCollectionItemTyp;
        if (src == null)
            e.Accepted = false;
        else if ( src.FirstName !=null && !src.FirstName.Contains(SearchFilter))// here is FirstName a Property in my YourCollectionItem
            e.Accepted = false;
    }
