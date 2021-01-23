               EntityContext Context = new EntityContext();
  
               Context.ContextOptions.LazyLoadingEnabled = True;//by default it is true
               var article = Articlerctx.Articles.Where(o=>o.ArticleID==id).FirstOrDefault();          
        
               Article.Category.Id or any other field from category.
 
