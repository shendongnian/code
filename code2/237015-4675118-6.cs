    // Extra casts added to get this to compile from a generic type
    Attachment o = (Attachment)(object)this;
    GenericDao<Attachment> dao  = (GenericDao<Attachment>)Dao;
    // No problem, the Save method on GenericDao<Attachment> 
    // takes a single parameter of type Attachment.
    dao.Save(o); 
