    public class MyClassName
    {
      // Variable to hold an instance of this class
      private static MyClassName _instance;
    
      // Private constructor, so only this class can create a copy of this class
      private MyClassName()
      {
        // ... Any constructor logic in here
      }
    
      // Any part of the program needing an instance of this class can only get it here.
      // There can only ever be one instance at a time.
      public static GetInstance()
      {
        if (this._instance == null)
        {
          this._instance = new MyClassName();
        }
    
        return this._instance;
      }
    
      // Finally the method for doing the DB stuff
      public ReturnType DoDatabaseStuff()
      {
            SqlConnection myCon = DBcon.getInstance().conn(); 
    
            try 
            { 
              myCon.Open(); 
              // ... do some DB stuff
            } 
            catch (Exception ex) 
            { 
                // ... Some logging
            } 
     	  finally
            {
               if (myCon.State == ConnectionState.Open)
               {
                  myCon.Close();
               }
               
               // ... any additional cleanup in here
            }
     
            return // ... some value; 
      }
    
    }
