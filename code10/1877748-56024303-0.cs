    public class GenericReportViewComponent : ViewComponent
    {
       public GenericReportViewComponent()
       {
       }
       public IViewComponentResult Invoke(GenericReportViewModel model)
       {
           return View(model);
       }
    }
