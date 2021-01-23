    public interface IUser {
      public Guid UserId { get; set; }
      public string UserName { get; set; }
      public IEnumerable<Posts> { get; set; }
    }
