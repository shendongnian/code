    public void UsersInCompany() {
        List<User> UsersInCompany = new List<User>();
        foreach (var userDB in UsersFromDataBase) {
            User user = new User() {
                Name = userDB.Name,
                SecondName = userDB.SecondName,
                //...
            };
            UsersInCompany.Add(user);    
        }
    }
