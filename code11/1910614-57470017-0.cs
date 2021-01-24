    var query = (
    from b in db.Blogs
    join p in db.Posts on b.Id equals p.BlogId
    from pt in db.PostTag.Where(posttag => posttag.PostId == p.Id).DefaultIfEmpty() //LEFT OUTER JOIN
    from t in db.Tags.Where(tag => tag.Id == pt.TagId).DefaultIfEmpty() //LEFT OUTER JOIN
    where (...) //Your additional conditions
    select new 
    {
    	BlogId = b.Id,
    	BlogTitle = b.Title,
    	PostId = p.Id,
    	PostTitle = p.Title,
    	p.PostContent,
    	TagId = (int?) t.Id,
    	TagName = t.Name
    }).ToList();
    
