    public static class StaticCache
    {
    
        public static Add(object obj)
        {        
            try {            
                HttpRuntime.Cache.Add(obj);            
            }
            catch(Exception ex) {
                //log or something            
            }        
        }    
    }
