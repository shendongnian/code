    private IEnumerable<entityFrameworkClass> TheList
    { 
        get
        { 
            if(_theList == null)
            {
                 _theList = from i in context select i;
            }
            return _theList; 
        }
    }
