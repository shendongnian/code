    class BlogPostRow
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Status { get; set; }
        public BlogPostRow()
        {
        }
        public BlogPostRow(BlogPost post)
        {
            Title = post.Title;
            Body = post.Body;
            PublishDate = post.PublishDate;
            Status = GetStatusText(post.Status);
        }
        public BlogPost CreateInstance(string blogName, IDbContext ctx)
        {
            Blog blog = ctx.Blogs.Where(b => b.Name == blogName).Single();
            BlogPost post = new BlogPost(blog)
            {
                Title = Title,
                Body = Body,
                PublishDate = PublishDate,
                Status = GetStatus(Status)
            };
            blog.Posts.Add(post);
            return post;
        }
        private BlogPostStatus GetStatus(string statusText)
        {
            BlogPostStatus status;
            foreach (string name in Enum.GetNames(typeof(BlogPostStatus)))
            {
                string enumName = name.Replace(" ", string.Empty);
                if (Enum.TryParse(enumName, out status))
                    return status;
            }
            throw new ArgumentException("Unknown Blog Post Status Text: " + statusText);
        }
        private string GetStatusText(BlogPostStatus status)
        {
            switch (status)
            {
                case BlogPostStatus.WorkingDraft:
                    return "Working Draft";
                default:
                    return status.ToString();
            }
        }
    }
