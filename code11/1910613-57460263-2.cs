    [Route("posts/{blogId}")]
        [HttpGet]
        public async Task<IActionResult> GetBlogPosts(int blogId)
        {
            var blogs = db.Blogs
                .Where(b => b.Id == blogId)
                .Include(b => b.Posts)
                    .ThenInclude(p => p.PostTags).ThenInclude(pt => pt.Tag)
                .Select(b=>new {
                    Id=b.Id,
                    Title=b.Title,
                    Posts= b.Posts.Select(p => new {
                        Id=p.Id,
                        Title=p.Title,
                        PostContent=p.PostContent,
                        Tags =p.PostTags.Select(pt=> new {
                            Id=pt.Tag.Id,
                            Name=pt.Tag.Name,
                        })
                    })
                });
            return Json(blogs);
        }
