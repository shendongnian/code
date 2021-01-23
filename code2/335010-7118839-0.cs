    public void SetUser(User user) 
    {    
       string streetNumber = String.Empty;     
       if (user!= null 
           && user.Address != null 
           && user.Address.StreetNo != null)       
       {
             streetNumber = user.Address.StreetNo.ToString();    
       }
    }
