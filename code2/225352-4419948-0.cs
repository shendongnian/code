    PublicationMediator.CalculateResults();
    List<Article> articles = PublicationMediator.GetResults(this.UniqueID)
                                                .PublicationList
                                                .OfType<Article>()
                                                .ToList();
