    public class MyAreaRegistration : AreaRegistration
     {
         public override string AreaName
         {
             get { return "My Area"; }
         }
    
         public override void RegisterArea(AreaRegistrationContext context)
         {
             context.MapRoute(
                 "news-articles",
                 "my-area/articles/after/{date}",
                 new {controller = "MyAreaArticles", action = "After"}
                 );
    
             // And so on ...
         }
    }
