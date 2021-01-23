    public class Subscription
    {
      public int Id { get; set; }
      public string Name { get; set; }
    
      // the column of your database
      public byte? autoRenew { get; set; }
    
      // the property you want
      [NotMapped]
      public bool Autorenew
      {
        get => autoRenew > 0;
        set { this.autoRenew = (byte)(value ? 1 : 0);  }
      }
    }
