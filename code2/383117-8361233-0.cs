    public bool IsValidEmployee(string email, string password, HttpSessionStateBase session)
    {
      bool valid = false;
      var employee = dataAccess.GetEmployee(email, password);
    
      if(employee! = null)
       {
          valid = true;
          session["Employee"] = employee;
       }
    
       return valid;
    }
