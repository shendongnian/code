    public TagCloudControl()
    {
        //this is now empty.
    } 
    public IEnumerable<Tag> Tags
    {
        get { return (this.ItemsSource as IEnumerable<Tag>); }
        set { this.ItemsSource = value; }
    }
