    public class User
    {
    	public virtual int UserId { get; set; }
    	public virtual int GroupId { get; set; }
    	public virtual IList<Location> Locations { get; set; }
    	public virtual Location Source { get; set; }
    	public override bool Equals(object obj)
    	{
		    if (obj == null)
			    return false;
		    var t = obj as User;
		    if (t == null)
    			return false;
		    if (UserId == t.UserId && GroupId == t.GroupId)
    			return true;
		    return false;
	    }
	    public override int GetHashCode()
	    {
    		return (UserId + "|" + GroupId).GetHashCode();
    	}
    }
    public class Source
    {
    	public virtual int Id { get; set; }
    }
    public class Location
    {
    	public virtual User User { get; set; }
    	public virtual int Id { get; set; }
    	public virtual Source Source { get; set; } 
    	public virtual string X { get; set; }
	    public virtual string Y { get; set; }
	    public override bool Equals(object obj)
	    {
		    if (obj == null)
		    	return false;
		    var t = obj as Location;
		    if (t == null)
		    	return false;
		    if (User == t.User && Source == t.Source)
		    	return true;
		    return false;
	    }
	    public override int GetHashCode()
	    {
	    	return (User.GetHashCode() + "|" + Id).GetHashCode();
	    }
    }
    public class UserMap : ClassMap<User>
    {
    	public UserMap()
    	{
		    CompositeId()
			    .KeyProperty(x => x.UserId, "UserId")
			    .KeyProperty(x => x.GroupId, "GroupId");
		    HasMany(x => x.Locations);
		    References(x => x.Source).Columns("UserId", "GroupId", "LocationSource");
	    }
    }
    public class LocationMap : ClassMap<Location>
    {
    	public LocationMap()
    	{
		    CompositeId()
			    .KeyReference(x => x.Source, "Source")
			    .KeyReference(x => x.User,"groupId","userid");
		    References(x => x.User).Columns("userid","groupid");
	    }
    }
    public class SourceMap : ClassMap<Source>
    {
    	public SourceMap()
    	{
		    Id(x => x.Id).GeneratedBy.Native();
	    }
    }
