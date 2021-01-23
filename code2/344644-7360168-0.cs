    [Obsolete("User PageName2")
    public string PageName {
    {
     get { return PageName2.ToString(); }
    set { PageName2 = (PageNameProperty )Enum.Parse(typeof(PageNameProperty), value);
    }
    
    public PageNameProperty PageName2 { set; get; }
