    public void Seed(ISession s) 
    {
      using(var tx = s.BeginTransaction() 
      {
        var account1 = new Account { FirstName = "Bob", LastName = "Smith" };
        var account2 = new Account { FirstName = "John", LastName = "Doe" };
        account1.AddFriend(account2); // manipulates a friends collection
        s.Save(account1);
      }
    }
