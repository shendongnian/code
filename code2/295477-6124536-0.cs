    public class CreateViewModel
    {
    public int Poll_id = {get ; set;}
    //...
    }
    
    //View would look like (inherits from CreateViewModel)
    <%: Html.TextBoxFor(m => m.Poll_id) %>
    
    //Controller
    public ActionResult Create()
    {
    CreateViewModel newCreateView= new CreateViewModel();
    return View(newCreateView);
    }
    [HttpPost]
    public ActionResult Create(CreateViewModel newCreateView)
    {
    //Put code to save all into database here
    return RedirectToAction("Index");
    }
