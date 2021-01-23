    [XmlIgnore]
    public string DocumentTitle
    {
        get
        {
            IHasTitle hasTitle = Document;
            return hasTitle.Title;
        }
    }
