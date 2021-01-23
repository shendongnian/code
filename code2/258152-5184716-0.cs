	var anonType =
		from c in ObjectContext.Contents
		join ct in ObjectContext.ContentTags on c.Id equals ct.ContentId
		join t in ObjectContext.Tags on ct.TagId equals t.Id
		where t.Name.ToLower().Contains(lowerTag)
		select new { Contents = c, ContentTags = ct, Tags = t }).AsEnumerable();
	IList<Contents> contentsForTag = anonType.Select(c => c.Contents).ToList();
