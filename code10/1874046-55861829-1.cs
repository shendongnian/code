     public object GetEntities<T>() 
     {
         using (DBContext db = new DBContext())
         {
                Repository<T> repository = new Repository<T>(db);
                list = repository.GetAll();
                return list.ToList();
         }
     }
