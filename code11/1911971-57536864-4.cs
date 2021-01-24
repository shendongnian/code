    public partial class Member
    {
    	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int Id { get; set; }
    	public bool Active { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	//[NotMapped] <-- remove this
    	public Address Address { get; set; }
    }
    
    public partial class Address
    {
    	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int Id { get; set; }
    	public string City { get; set; }
    	//public int MemberId { get; set; } <-- remove this
    	public int StateId { get; set; }
    	public string StreetAddress { get; set; }
    	public string ZipCode { get; set; }
    	public string Unit { get; set; }
    	[NotMapped]
    	public bool IsNew => this.Id < 1;
    }
