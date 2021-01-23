    public class User() {
      public int Id { get; set; }
      public string Roles { get; set; }
      public string[] RolesArray 
      { 
        get
        {
          return Roles.Split(',').ToArray();
        }
        set
        {
          Roles = String.Join(',', value);
        }
      }
    }
