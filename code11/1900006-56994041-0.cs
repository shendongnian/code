public class Package
{
    [Key]
	[Required]
    public Int32? PackageID { get; set; }
    [Required]
    [MaxLength(20)]
    public String Name { get; set; }
	[Required]
    public Boolean Active? { get; set; }
}
So far, okay, with this I needed to somehow use the mechanism of my query, and I was able to do it by calling the Entity framework called the procedure and with nullable parameters, the final result was like this:
public List<Package> Retreave(Package entity)
{
	using (MyDatabaseContext db = new MyDatabaseContext())
	{
		return db.Database
			.SqlQuery<Package>
			(
				"PROC_PACKAGE_SELECT @PackageID, @Name, @Active"
				, new SqlParameter("@PackageID", (object)entity.PackageID ?? DBNull.Value)
				, new SqlParameter("@Name", (object)entity.Name ?? DBNull.Value)
				, new SqlParameter("@Active", (object)entity.Active ?? DBNull.Value)
			)
				.ToList<Package>();
	}
}
I ran several tests, and in that case the query was 100% flexible for my needs.
I really hope this effort can help someone in the community.
