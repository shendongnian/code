    public void EmailAlert(string email) {  }
    
    public void Register(string email, ...) { }
    
    public string FindEmail(string email) 
    { 
        //query
        SELECT *            
        FROM Table
        WHERE Email = 'passed in email'
        //pseudo code
        if (email exists)
        {
            return email address;
        }
        return null; 
     } //returns null if none found
