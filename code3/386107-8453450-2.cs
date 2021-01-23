    public class TagComparer : IEqualityComparer<Tag>
    {
    	public bool Equals(Tag a, Tag b)
    	{
    		return a.TagId == b.TagId;
    	}
    }
    
    Users.OrderBy(o => o.Tags.Intersect(CurrentUser.Tags, new TagComparer()).Count)
