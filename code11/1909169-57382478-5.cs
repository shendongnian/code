public class IOrderService
{
    string SetOrderNumber();
}
public class OrderService : IOrderService
{
    private readonly Random random = new Random();
    private string loadOrderNr()
    {
       long part1 = rnd.Next(100000, 999999);
       long part2 = rnd.Next(1000, 9999);
       return "CA-" + part1 + "-" + part2;
    } 
    public string SetOrderNumber()
    {
        var OrderNumber = "";
        do
        {
           OrderNumber = loadOrderNr();
        }
        while (db.CarAnn.Any(x => x.OrderNr == OrderNumber));
    }
}
After you have added the OrderService into your project - could be at the Service-Layer or as in the example in another Folder called ```Services``` that holds all the Service-Classes and Interfaces - you need to inject the service into your controller.
Then you can simply use it. This is the way to achieve a separation of concerns!
Controller-Logic
using System.Web.Mvc;
using ExampleProject.Services;
namespace ExampleProject.Controllers
{    
    public class ExampleController : Controller
    {
        private IOrderService _orderService;
        public ExampleController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public ActionResult Post(Model model)
        {
      
            using (Db db = new Db())
            {
             var ann = new CarAnn()
             {
                Description = model.Description;
                Title = model.Title;
                OrderNr = _orderService.SetOrderNumber(); 
              };                         
            }
            db.CarAnn.Add(ann);
            db.SaveChanges();
            return Ok();
        }
    }
}
In my opinion, the Database-Context should be injected as well - but to be honest I am not sure how to do this. I am more familiar with ASP.NET-Core. ;)
For further information for dependency-injection look here: [ASP.NET-Documentation][1]
  [1]: https://docs.microsoft.com/de-de/aspnet/mvc/overview/older-versions/hands-on-labs/aspnet-mvc-4-dependency-injection
