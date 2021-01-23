    public class UserResource {
      public virtual int UserResourceId { get; protected set; }
      public virtual User User { get; set; }
      public virtual Resource { get; set; }
      public virtual string AccessLevel { get; set; }
    }
