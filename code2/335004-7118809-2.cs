    public void SetUser(User user)
    {
       if (user != null) {
           throw new System.ArgumentException("user cannot be null", "user");
       }
       if (user.Address != null) {
           throw new System.ArgumentException("Address cannot be null", "Address");
       }
       
       string streetNumber = "";
    
       if (user.Address.StreetNo != null)
          streetNumber = user.Address.StreetNo.ToString();
       else
         streetNumber = "";
    }
