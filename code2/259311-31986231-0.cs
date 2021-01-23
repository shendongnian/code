    long id;
    IGenericQueryRepository<myentityclass, Entityname> InfoBase = null;
    try
     {
        InfoBase = new GenericQueryRepository<myentityclass, Entityname>();
        InfoBase.Add(generalinfo);
        InfoBase.Context.SaveChanges();
        id = entityclassobj.ID;
        return id;
     }
