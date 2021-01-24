    public partial class Member
    {
    	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int Id { get; set; }
    	public bool Active { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public ICollection<Address> Addresses { get; set; }
    }
