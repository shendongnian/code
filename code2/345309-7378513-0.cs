    public bool DoPost( CommunityNewsPost post )
    {
        MembershipHelper.ThrowUnlessAtLeast( RoleName.Administrator );
        DateTime value;
        DateTime? start;
        DateTime? end;
        DateTime.TryParse( post.PublishStart, out value );
        start = ( value != DateTime.MinValue ) ? new DateTime?(value.Date) : null;
        DateTime.TryParse( post.PublishEnd, out value );
        end = ( value != DateTime.MinValue ) ? 
             new DateTime?(value.Date.AddMinutes(-1.0 )) : null;
        
        return CommunityNews.Post(post.Title, post.Markdown, post.CategoryId, 
             start, end);
    }
