    public class ErrorForm 
    {
       private static ErrorForm instance;
    
       private ErrorForm() {}
    
       public static Singleton GetInstance()
       {
          if (instance == null)
          {
             instance = new ErrorForm();
          }
          else //OR Reuse it
          {
              instance.Close(); 
              instance = new ErrorForm();
          }
          return instance;      
       }
       public Errors ErrorMessages
       {
          set {...}
       }
    }
