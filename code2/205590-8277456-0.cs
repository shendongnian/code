    public List<Articles>  getArticles( ){  
     using (var db = new ArticleNetEntities())
         {
                 articles = db.Articles.Where(something).ToList();
         }
    }
