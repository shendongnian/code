    var model = this.Context
                    .Blogs
                    .Select( b => new BlogViewModel {
                        b.ID,
                        b.Name,
                        b.CreatedDate,
                        PostedBy = b.Author.Name,
                        b.Body,
                        Tags = b.Tags
                                .Select( t => new TagViewModel { t.Tag, t.ID } )
                                .ToList()
                     })
                    .ToList();
