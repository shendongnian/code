    //the alias for post
    Post post = null; 
    var list = Session.QueryOver(() => post)
                .WithSubquery.WhereProperty(() => post.Id)
                    .In(NHibernate.Criterion.QueryOver.Of<Comment>()
                        .Where(c => c.Name == "Name")
                        .Select(c => c.Post.Id))
                .Take(5)
                .List();
