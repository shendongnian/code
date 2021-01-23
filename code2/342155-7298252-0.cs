    public Guid AccommPropertyGUID 
    {
        get 
        {
             if(null != _accommpropertyguid)
                 {
                     var model = GetSingle(accommPropertyID);
                     _accommpropertyguid = model.AccommPropertyGUID;
                 }
    
              return _accommpropertyguid;
        }
    }
