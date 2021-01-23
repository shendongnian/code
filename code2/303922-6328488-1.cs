         string rowKeyToUse = string.Format("{0:D19}", 
    		DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
    var blogs = 
        from blog in context.CreateQuery<Blog>("Blogs")
        where blog.PartitionKey == "Football" 
    	 	&& blog.RowKey.CompareTo(rowKeyToUse) > 0
      select blog;
