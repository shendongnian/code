    public static void MyMethod( object _anyObject )
    {
        IEnumerable list = _anyObject as IEnumerable;
        if ( list != null )
        {
            foreach ( var item in list )
            {
                // Do whathever you want.
            }
        }
        else
        {
            // Probably just a plain object, not a collection.
        }
    }
