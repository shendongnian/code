    public string PageName
    {
        set 
        { 
            if (value == null)
               throw new NullReferenceException();
            if (!(new string[] { "master", "content" }.Contains(value.ToLower()))
               throw new InvalidOperationException();
    
            _pageName = value; 
        }
        get
        {
           return _pageName;
        }
    }
