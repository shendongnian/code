    public static class UIExtension
    {
       public static ComponentFactory MyExtensions(this HtmlHelper html)
       {
           return new ComponentFactory(html);
       }
    
       public static ComponentFactory<TModel> MyExtensions<TModel>(this HtmlHelper<TModel> html) 
          where TModel : class
       {
           return new ComponentFactory<TModel>(html);
       }
    }
