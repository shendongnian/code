    private Func<int, SomeEntity> _getCached;
    public SomeEntity Get(int id)
    {
        if (_getCached == null)
        {
            Func<int, SomeEntity> func = GetImpl;
            _getCached = func.AsCached();
        }
        return _getCached(id);
    }
    private SomeEntity GetImpl(int id)
    {
        return base.GetItem<SomeEntity>
                   ("select * from SomeEntities where id = @idParam",
                    new { idParam = id}); 
    }
