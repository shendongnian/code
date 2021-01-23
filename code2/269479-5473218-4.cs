    public virtual string UniqueID { 
        get { 
            if (_cachedUniqueID != null) {
                return _cachedUniqueID; 
            }
            Control namingContainer = NamingContainer;
            if (namingContainer != null) { 
                // if the ID is null at this point, we need to have one created and the control added to the
                // naming container. 
                if (_id == null) { 
                    GenerateAutomaticID();
                } 
                if (Page == namingContainer) {
                    _cachedUniqueID = _id;
                } 
                else {
                    string uniqueIDPrefix = namingContainer.GetUniqueIDPrefix(); 
                    if (uniqueIDPrefix.Length == 0) { 
                        // In this case, it is probably a naming container that is not sited, so we don't want to cache it
                        return _id; 
                    }
                    else {
                        _cachedUniqueID = uniqueIDPrefix + _id;
                    } 
                }
                return _cachedUniqueID; 
            }
            else { 
                // no naming container
                return _id;
            }
        } 
    }
