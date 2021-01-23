    public class HomeController: Controller
    {
        public ActionResult Index() 
        {
            var model = new MyViewModel
            {
                Items = db.measurement_unit.Select(x => new SelectListItem
                {
                    Value = x.id_um.ToString(),
                    Text = x.name.ToString()
                })
            };
            return View(model);
        }
    }
