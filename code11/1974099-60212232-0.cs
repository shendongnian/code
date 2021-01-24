[HttpGet]
public ActionResult Index()
{
     IndexViewModel viewModel = GetIndexModel();
     // Add action logic here
     return View(viewModel);
}
[HttpGet]
public IndexViewModel GetIndexModel() {
   // return the view model.
}
The second get function can be used as xhr request from your angular application. This is not really recommended. Going angular is a good opportunity to turn your api to Rest and properly handle the data in your spa.
