    public List<MyObject> GetObjects()
    {
 
     using (DatabaseDataContext context = new DatabaseDataContext())
     {
     var objects = context.GetObjectsFromDB();  
     return new  List<MyObject>(objects);
     }
    }
