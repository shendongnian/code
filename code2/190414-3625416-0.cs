         public bool IsUsed  
         {   
             get 
             {    
              ClassA a = new ClassA();    
              Collection<ClassA> myCollection;
          
              try
              {
                  myCollection = a.FindObject("Id = 1","");
              }
              catch (SqlServerTimedOutException ex)
              {
                  throw new MyApplicationException("Cannot evaluate if is in use.", ex);
              }
              if(..) // etc   
             } 
        }
