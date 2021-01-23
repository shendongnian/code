    using System.Web.Mvc.Html;
    public void Index()
            {
                StringBuilder resultContainer = new StringBuilder();
                StringWriter sw = new StringWriter(resultContainer);
    
                ViewContext viewContext = new ViewContext(ControllerContext, new WebFormView(ControllerContext, "fakePath"), ViewData, TempData, sw);
    
                HtmlHelper helper = new HtmlHelper(viewContext, new ViewPage());
    
                helper.RenderAction("create");
    
                sw.Flush();
                sw.Close();
                resultContainer.ToString(); //"This is output from Create action"
            }
    public ActionResult Create()
            {
                return Content("This is output from Create action");
            }
