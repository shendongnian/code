     public class WrappedViewResult : ViewResult
        {
            private readonly object model;
            public WrapInDtuViewResult()
            {
                
            }
    
            public WrapInDtuViewResult(object model)
            {
                this.model = model;
            }
    
    
            public override void ExecuteResult(ControllerContext context)
            {
    
                if (string.IsNullOrWhiteSpace(this.ViewName))
                {
                    this.ViewName = context.RouteData.Values["action"].ToString();
                }
                ViewEngineResult result = this.FindView(context);
    
                context.Controller.ViewData.Model = model;
                ViewDataDictionary viewData = context.Controller.ViewData;
                TempDataDictionary tempData = context.Controller.TempData;
    
                var writer = new StringWriter();
                ViewContext viewContext = new ViewContext(context, result.View, viewData, tempData, writer);
                result.View.Render(viewContext, writer);
    
    
                var content = writer.ToString();
    
    
                Scraping scraping = new Scraping();
                if (AppSettings.UseScraping)
                {
                    content = scraping.Render(content);
                }
                else
                {
                    content = "<html><head><script src='/Scripts/jquery-1.7.1.min.js' type='text/javascript'></script></head><body>" + content + "</body></html>";
                }
    
                context.HttpContext.Response.Write(content);
            }
        }
