    public bool AddCustomer()
    {
      try{
         ....
         db.SubmitChanges();
         return true;
      }
      catch(Exception e)
      {
        ...
        return false;
      }
    }
