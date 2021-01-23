    public void SetStatus(string statusFlag)
    {
        if (_xmlAttributes == null)
            _xmlAttributes = new Dictionary<CD, string>();
    
        _xmlAttributes.Add(CD.CD_1, statusFlag);
        _xmlAttributes.Add(CD.CD_2, statusFlag);
        _xmlAttributes.Add(CD.CD_3, statusFlag);
    
        if (_primaryZone != null)
            _xmlAttributes.Add(CD.CD_4, statusFlag);
    
        if (_mgr1 != null)
            _xmlAttributes.Add(CD.CD_10, statusFlag);
    
        if (_mgr2 != null)
            _xmlAttributes.Add(CD.CD_11, statusFlag);
    
        if (_mgr3 != null)
            _xmlAttributes.Add(CD.CD_5, statusFlag);
    
        if (_producer != null)
            _xmlAttributes.Add(CD.CD_6, statusFlag);
    
        if (_countTest > 0)
            _xmlAttributes.Add(CD.CD_7, statusFlag);
    
        if (_list1 != null && _list1.Count > 0)
            _xmlAttributes.Add(CD.CD_8, statusFlag);
    
        if (_list2 != null && _list2.Count > 0)
            _xmlAttributes.Add(CD.CD_9, statusFlag);
    }
