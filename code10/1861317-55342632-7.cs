    public partial class MyEntity : IBaseEntity<long>
    {
      [Required]
      public override long  Id 
      {
    	get { return base.Id;}
    	set { base.Id = value;}
      }
    }
