    public IEnumerable<Post> GetPostsByTags(IEnumerable<Tag> tags)
    {
        return from p in context.Posts
               where p.PostTags.Any(pt => tags.Any(t => t.TagID == pt.TagID)) &&
                     p.PostDate != null                    
               orderby p.PostDate descending
               select p;
    }
