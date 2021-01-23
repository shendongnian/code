    class FakeUserRepo : IUserRepository
    {
      public string GetUserName(int id)
      {
        return "FakeUser";
       }
    }
