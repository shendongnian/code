    public partial class Driver
    {
         public int Id { get; set; }
         // other properties
         [UIHint("Licenses")]
         public virtual ICollection<License> Licenses { get; set; }
    }
