    public static class AddHelper 
    {
    
    
       public void AddAll(this ObjectSet<T> objectSet,IEnumerable<T> items)
       {
       
            foreach(var item in items)
    		{
    		   objectSet.AddObject(item);
    		
    		}
       
       }
    
    }
