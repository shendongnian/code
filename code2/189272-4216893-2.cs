    public static class MyViewHelper
    {
      public static string RenderPartialToString(ControllerContext context
         , string partialViewName
         , ViewDataDictionary viewData
         , TempDataDictionary tempData)
      {
         ViewEngineResult result = 
            ViewEngines.Engines.FindPartialView(context, partialViewName);
         
         if (result.View != null)
         {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
               using (HtmlTextWriter output = new HtmlTextWriter(sw))
               {
                  ViewContext viewContext = new ViewContext(
                     context, result.View, viewData, tempData, output);
                  result.View.Render(viewContext, output);
               }
            }
            return sb.ToString();
         }
         return String.Empty;
      }
    }
   
