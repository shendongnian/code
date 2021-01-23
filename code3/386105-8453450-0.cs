    public class TagComparer : IEqualityComparer<Tag>
    {
    	public int Compare(Tag a, Tag b)
    	{
    		return Comparer<int>.Default.Compare(a.TagId, b.TagId)
    	}
    }
    
    Users.OrderBy(o => o.Tags.Intersect(CurrentUser.Tags, new TagComparer()).Count)
