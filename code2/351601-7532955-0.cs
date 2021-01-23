    public class User
    {
      public virtual int Id { get; set; }
      public virtual string FirstName { get; set; }
      
      public virtual string PhoneNumber
      { 
          get { return this.PhoneNumber.ToString(); } // TODO: check for null
          set { this.PhoneNumber = PhoneNumber.Parse(value); }
      }
      
      [NotMapped]
      public virtual PhoneNumber Phone { get; set; }
    }
