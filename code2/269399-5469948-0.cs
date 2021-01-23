    public List<MyClass> CachedItems
    {
        get
        {
            return (List<MyClass>)( ViewState["CachedItems"] = ViewState["CachedItems"] ??
                    new List<MyClass>());
        }
    }
