    public static class MyFormExtensions { 
      public static MvcForm BeginForm(this HtmlHelper htmlHelper, Object htmlAttributes)
      {
         return htmlHelper.BeginForm(null, null, FormMethod.Post, htmlAttributes);
      }
    }
