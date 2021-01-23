    bool valid = false;
    using (PrincipalContext checkpass = new PrincipalContext(ContextType.Machine)) //checks local machine first
           {
              try // you need to use try catch when you only have local user
              {
                  valid = checkpass.ValidateCredentials(user, password);
              }
              catch (Exception ex) { valid = true; }
              if (valid)
              {
                   // returns ok   
              }
              else
              {
                  // returns false
              }
