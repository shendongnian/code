    public uint GetObjectId(object obj)
    {
        uint id = 0;
        var objType = obj.GetType();
        // busco si el type está registrado
        if (_typeMap.Keys.Contains(objType))            
        {
            id = (uint) _typeMap[objType].Method.Invoke(obj, new object[] { obj } );                
        }
        return id;
    }
