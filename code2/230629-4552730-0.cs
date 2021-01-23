    Public int GetAllCustomers()
    {
         try
         {
              return data.GetAllCustomers()
         }
         catch()
         {
             Logger.log("Error calling GetAllCustomers");
         }
    }
         //data
    Public static int GetAllCustomers()
    {
         try
         {
              //db operations...
         }
         catch(Exception ex)
         {
              Logger.log(ex.Stacktrace);
              throw ex;
         }
    }
