    public IEnumerable<string> Ages{
       get{
          return _innerList.Select(s => s.stringProperty);
       }
    }
