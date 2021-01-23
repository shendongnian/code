    var _db = new YourDbContext( );
    for( int i = 0; i < 6000; i++ )
    {
        FoobarObj newObject = new FoobarObj( )
        {
            Name = "xyz_" + i.ToString( );
        };
        _db.FoobarObjects.InsertOnSubmit( newObject );
    }
    _db.SubmitChanges( );
