    public class AdminController : Controller
    {
        public linqVipDataContext db = new linqVipDataContext();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            IEnumerable<SelectListItem> ProductItems = db.Products.AsEnumerable().Select(c => new SelectListItem()
            {
                Text = c.name,
                Value = c.id.ToString(),
                Selected = true,
            });
            SelectList prod = new SelectList(ProductItems, "Value", "Text");
            ViewBag.ProductList = prod;
            return View();
        }
        //
        //Fill the Design List..
        public JsonResult GetDesigns(int productId)
        {
            /*var data = dbs.Designs.Where(d => d.master_id == productId).ToList();*/
            IEnumerable<SelectListItem> DesignItems = db.Designs.Where(c => c.master_id == productId).AsEnumerable().Select(c => new SelectListItem()
            {
                Text = c.name,
                Value = c.id.ToString()
            });
            SelectList des = new SelectList(DesignItems, "Value", "Text");
            return Json(des, JsonRequestBehavior.AllowGet);
        }
        //
        //Fill the Model List..
        public JsonResult GetModels(int designId)
        {   
            /*This code down here! Doesnt work and says it's type is unknown*/
            /*var data = dbs.Models.Where(d => d.design_id == designId).ToList();*/
            /*For that reason im using this code*/
            IEnumerable<SelectListItem> ModelItems = db.Models.Where(d => d.design_id == designId).AsEnumerable().Select(c => new SelectListItem()
            {
                Text = c.name,
                Value = c.id.ToString()
            });
            SelectList mods= new SelectList(ModelItems, "Value", "Text");
            return Json(mods, JsonRequestBehavior.AllowGet);
        }
