    public bool IsDirty
    {
       get
       {
            return _isDirty || B.IsDirty || C.IsDirty /* etc */;
       }
    }
