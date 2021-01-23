    private ObjectQuery<E> GetEntity()
    {   // Pluralization concern.  Table and Type need to be consistently named.
        // TODO: Don't get cute with database table names.  XXX and XXXs for pluralization
        return _dc.CreateQuery<E>("[" + e.EntityKey.EntitySetName + "]");
    }
