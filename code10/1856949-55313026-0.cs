    public interface IUserRepository 
    {
      User GetById(Guid userId);
      ReadOnlyCollection<User> GetAll();
    }
