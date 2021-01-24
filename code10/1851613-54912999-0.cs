public class MyViewModelItem {
    public int LowHouse { get; set; }
    public int HighHouse { get; set; }
    public char Side { get; set; }
}
public class MyViewModel {
    // Your other view's properties
    public List<MyViewModelItem> List { get; set; }
}
And your controller like this:
public class MyController : Controller {
    private readonly IMyService myService;
    public MyController()
    {
        myService = new MyService(); // Consider Dependency Injection
    }
    public ActionResult Index() {
        var data = myService.List();
        var myModel = MapMyModel(data);
        return View(myModel);
    }
    private MyViewModel MapMyModel(IEnumerable<YOUR_ENTITY> data) {
        var myModel = new MyViewModel();
        myModel.List = new List<MyViewModelItem>();
        foreach (var item in data)
        {
            myModel.List.Add(new MyViewModelItem {
                LowHouse = item.ODD_LOW,
                HighHouse = item.ODD_HIGH,
                Side = [your logic]
            })
        }
    }
}
References:
 1. [Use ViewModels to manage data & organize code in ASP.NET MVC applications](http://rachelappel.com/use-viewmodels-to-manage-data-amp-organize-code-in-asp-net-mvc-applications/)
 2. [ASP.NET MVC View Model Patterns](https://stevemichelotti.com/aspnet-mvc-view-model-patterns/)
