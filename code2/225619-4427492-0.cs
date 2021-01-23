    public T GetEntity<T>(int id) where T : class 
        { 
            
            return db.GetTable<T>().AsEnumerable().SingleOrDefault(o => (int)o.GetType().GetProperty("Id").GetValue(o,null) == id);
        
        } 
