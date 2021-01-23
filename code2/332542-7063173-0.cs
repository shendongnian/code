    public class ArticleViewModelResponse {     
           public int article_id{set;get;}     
           public string comment{set;get;} 
           public int Id {get; set;} 
       } 
     [HttpPost]   
      public ActionResult DodajKomentarz( ArticleViewModelResponse comment) 
      {   //...   } 
