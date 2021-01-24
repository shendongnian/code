    class GetUserSecondOption
    {
        public GetUserSecondOption(UserFactory factory) { this.Factory = factory; }
        public void UsersInCompany()
        {
            List<User> UsersInCompany = new List<User>();
            foreach (var userDB in UsersFromDataBase)
            {
                var user = this.Factory.CreateNewUser();
                user.Name = userDB.Name;
                user.SecondName = userDB.SecondName;
                //...
    
                UsersInCompany.Add(user);    
            }
        }
    }
