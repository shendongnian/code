    public Uri GetUri(object obj)
    {
        IHasUri hasUri = obj as IHasUri;
        if(hasUri != null)
          Uri uri = hasUri.GetUri();
        
        // bla bla bla 
    }
