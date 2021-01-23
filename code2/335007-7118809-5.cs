    public void SetUser(User user)
    {
       string streetNumber = "";
    
       if (user != null && user.Address != null && user.Address.StreetNo != null) {
          streetNumber = user.Address.StreetNo.ToString();
       }
    }
