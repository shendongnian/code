    public class AddController : Controller
        {
            OrderEntities db = new OrderEntities();// New instance of db.
    
    
    
    [HttpPost]
            public ActionResult Index(string searchTerm)
            {
                var vm = new ViewModel();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    vm.AllClients = new List<Client>();
                }
                else
                {
                    vm.AllClients = db.Clients.Where(x => 
                    x.RefNo.ToString().Equals(searchTerm)).ToList();
    
                    foreach (Client client in vm.AllClients)
                    {
                        vm.ThisClient = client;//Attempt at a different solution
                        break;
                    }
    
                }
                    return View(vm);
            }
    
    [HttpPost]
    public ActionResult InsertOrder(ViewModel vm)
            {
                Order order = new Order();
    
                order.ClientID = vm.AllClients[0].ID;//Here is where the error gets thrown
                return RedirectToAction("Index");
            }
