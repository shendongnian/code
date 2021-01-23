    public List<MyObject> GetObjects()
    {
      List<MyObject> objects = null; // no need to "new" here
      using (DatabaseDataContext context = new DatabaseDataContext())
      {
        var tmp = context.GetObjectsFromDB();
        if (tmp != null) 
        {
          if (tmp.Count() > 0)
          {
            objects = (List<MyObject>)tmp.ToList();
          }
        }
      }
      return objects;
    }
