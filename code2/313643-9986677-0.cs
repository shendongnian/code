    DAL.Moles.MDALEntities.Constructor = (a) => { };
    DALEntities db = new DALEntities(); //Object Context
    
    System.Data.Objects.Moles.MObjectContext.AllInstances.CreateObjectSet<ObjectSetType>(
    (a) => { return new System.Data.Objects.Moles.MObjectSet<ObjectSetType>(); }
    );
    
    ObjectSet<ObjectSetType> dbList = db.CreateObjectSet<ObjectSetType>();
