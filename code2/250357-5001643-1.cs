    private Dictionary<CD, Func<bool>> _statusSetConditions;
    
    public MyCustomType()
    {
        _statusSetConditions = new Dictionary<CD, Func<bool>>();
        _statusSetConditions.Add(CD.CD_1, () => true);
        _statusSetConditions.Add(CD.CD_2, () => true);
        _statusSetConditions.Add(CD.CD_3, () => true);
        _statusSetConditions.Add(CD.CD_4, () => _primaryZone != null);
        ...
        _statusSetConditions.Add(CD.CD_11, () => _mgr2 != null);
    }
    public void SetStatus(string statusFlag)
    {
        if (_xmlAttributes == null)
            _xmlAttributes = new Dictionary<CD, string>();
    
        foreach (CD cd in Enum.GetValues(typeof(CD)))
            AddStatusAttribute(cd, statusFlag);
    }
    
    private void AddStatusAttribute(CD cd, string statusFlag)
    {
        Func<bool> condition;
    
        if (!_statusSetConditions.TryGetValue(cd, out condition))
            return; // or throw exception
    
        if (condition())
            _xmlAttributes.Add(cd, statusFlag);
    }  
