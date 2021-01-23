    public class RepositoryFactory {
    
       public IRepository GetRepository(string connection) 
       {
            if(SomeTestOnConnect(connection))
                return new SimpleRepository(connection);
            else
               return new FullRepository(connection);
    
       }
    }
