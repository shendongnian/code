    public void Del(E entity) // where E : EntityObject on the class
    {   if( entity != null)
        {
            DC.Attach(entity);
            DC.DeleteObject( entity);
            DC.SaveChanges();
        }
    }
