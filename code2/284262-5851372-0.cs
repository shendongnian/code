    var query1 = from a in db.Cabinets
      from b in db.Commodities
      from e in db.sArticleNumbers
      from d in KurvInnhold
      where
      KurvInnhold.select(k => k.VareKjøpt).Contains(e.ArtNum) &&
      a.ArticleNumberID == e.ID &&
      a.ArticleNumberID == b.ArticleNumberID
        
     select new
      {
           ArtNum = e.ArtNum,
           Price = b.Price,
           ModelName = a.ModelName,
      }.ToList();
    
    var query2 = 
      from a in query1
      join b in KurvInnhold on a.ArtNum equals b.VareKjøpt
      select new
      {
           BestiltAntall = b.AntallValgt,
           Price = a.Price,
           ModelName = a.ModelName,
      };
    
    Handlekurv1.DataSource = query2;
    Handlekurv1.DataBind();
