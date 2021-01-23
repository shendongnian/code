    public List<MyObject> GetObjects()
    {  
     using (DatabaseDataContext context = new DatabaseDataContext())
     {
      List<MyObject> objects = (List<MyObject>)context.GetObjectsFromDB();  
      return objects;
     }
    }
