    public class GenericReportViewComponent : ViewComponent
    {
       public IViewComponentResult Invoke(GenericReportViewModel model)
       {
           return View(model);
       }
    }
