    public class User
    {
      private readonly int _id;
      public User(int id)
      {
        _id = id;
      }
      public int ID
      {
        get { return _id; }
      }
      public bool IsGuest
      {
        get { return _id == 0; }
      }
    }
