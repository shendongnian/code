    public List<MyObject> GetObjects()
    {
     List<MyObject> objects = new List<MyObject>();
     using (DatabaseDataContext context = new DatabaseDataContext())
     {
     var objects = context.GetObjectsFromDB();  
     return new  List<MyObject>(objects);
     }
    }
