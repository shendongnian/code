    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<Article, ArticleFormView>()
            .ForMember(articleFormView => articleFormView.GroupIds, opts =>
                opts.MapFrom(article => article.ArticleGroups.Select(articleGroup => articleGroup.GroupId)));
        cfg.CreateMap<ArticleFormView, Article>()
            .ForMember(article => article.ArticleGroups, opts =>
                opts.MapFrom(articleFormView => articleFormView.GroupIds.Select(id => new ArticleGroup
                {
                    // Uncomment these two lines if you need them.
                    //Article = new Article { Title = articleFormView.Title, ArticleId = articleFormView.ArticleId },
                    //Group = new Group { GroupId = id },
                    ArticleId = articleFormView.ArticleId,
                    GroupId = id,
                })));
    });
