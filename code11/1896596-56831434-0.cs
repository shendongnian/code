asp
public class User {
	public int Id { get; set; }
	// Other properties
}
public class Organization {
	public int Id { get; set; }
	// Other properties
}
public class Role {
	public int Id { get; set; }
	// Other properties
}
If the case is like this (a user in an organization can have one role at most in that organization), then you can relate all three models by creating a new model that do that for you.
asp
public UserOrganizationRole {
	public int Id { get; set; }
	
	// Other properties if you want
	
	public int UserId { get; set; }
	public int OrganizationId { get; set; }
	public int RoleId { get; set; }
	
	public User User { get; set; }
	public Organization Organization { get; set; }
	public Role Role { get; set; }
}
Or create 2 models, one to relate Users and Organizations as M2M say UserOrganizations, and the other to relate UserOrganizations and Roles as M2M
asp
public UserOrganization {
	public int Id { get; set; }
	
	// Other properties if you want
	
	public int UserId { get; set; }
	public int OrganizationId { get; set; }
	
	public User User { get; set; }
	public Organization Organization { get; set; }
}
public UserOrganizationRole {
	public int Id { get; set; }
	
	// Other properties if you want
	
	public int UserOrganizationId { get; set; }
	public int RoleId { get; set; }
	
	public UserOrganization UserOrganization { get; set; }
	public Role Role { get; set; }
}
