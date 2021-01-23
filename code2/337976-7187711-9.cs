    public class GuidsController : Controller
    {
        public GuidRepository GuidRepo { get; private set; }
    
        public GuidsController(GuidRepository guidRepo)
        {
            GuidRepo = guidRepo;
        }
    
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var guid = GuidRepo.GetForId(id);
            var guids - GuidRepo.All();
    
            return View(new GuidModel { Guid = guid, Guids = guids });
        }
    
        [HttpPost]
        public ActionResult Edit(GuidModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
    
            /* update db */
        
            return RedirectToAction("Edit");
        }
    }
