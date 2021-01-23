    public void SetUser(User user)
    {
       if (user == null) {
           throw new System.ArgumentNullException("user", "user cannot be null");
       }
       if (user.Address == null) {
           throw new System.ArgumentNullException("Address", "Address cannot be null");
       }
       
       string streetNumber = "";
    
       if (user.Address.StreetNo != null) {
          streetNumber = user.Address.StreetNo.ToString();
       }
    }
