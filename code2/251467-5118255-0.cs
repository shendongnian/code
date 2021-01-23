    var posts =
	  from post in context.Posts.Include(p => p.Author).Include(p => p.Tags).Include(p => p.Categories)
	  where post.Comments.Any(c => c.IsPublic)
	  select post;
	var counts =
	  from post in context.Posts
	  where post.Comments.Any(c => c.IsPublic)
	  select new { PostId = post.Id, Count = post.Comments.Count() };
	var countDictionary = counts.ToDictionary(e => e.PostId, e => e.Count);
	foreach (var item in posts)
	{
	  System.Console.WriteLine("PostId {0}, TagCount {1}, PublicCommentCount {2}", item.Id, item.Tags.Count, countDictionary[item.Id]);
	}
