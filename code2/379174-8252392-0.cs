    string officeLocation = "";
    // office location could be either World, Europe, Africa, America, Asia, Pacific
    var result = articles.Select(a => new
    {
        Title = a.Title,
        Url = a[SPBuiltInFieldId.FileRef],
        Byline = a[Constants.FieldNames.Byline],
        ArticleDate = a[Constants.FieldNames.ArticleStartDate],
        RankWorld = a[Constants.FieldNames.World],
        RankEurope = a[Constants.FieldNames.RankEurope],
        RankAfrica = a[Constants.FieldNames.RankAfrica],
        RankAmerica = a[Constants.FieldNames.RankAmerica],
        RankAsia = a[Constants.FieldNames.RankAsia],
        RankPacific = a[Constants.FieldNames.RankPacific],
    });
    switch (officeLocation)
    {
        case "World": result = result.OrderBy(a => a.RankWorld); break;
        case "Europe": result = result.OrderBy(a => a.RankEurope); break;
        case "Africa": result = result.OrderBy(a => a.RankAfrica); break;
        case "America": result = result.OrderBy(a => a.RankAmerica); break;
        case "Asia": result = result.OrderBy(a => a.RankAsia); break;
        case "Pacific": result = result.OrderBy(a => a.RankPacific); break;
        default: throw new Exception("Unexpected location: " + officeLocation);
    }
    rptArticles.DataSource = result.OrderBy(a => a.RankWorld);
    rptArticles.DataBind();
