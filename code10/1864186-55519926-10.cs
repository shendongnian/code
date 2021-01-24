    public class MasterController<T> : Controller where T : MasterTemplate, new()
    {
        private ApplicationDbContext _context { get; set; }
        private string UserId { get; set; }
        public MasterController()
        {
            _context = new ApplicationDbContext();
            UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }
        public ActionResult Index(int id = 0)
        {
            T data = new T();
            if (id > 0)
                data = _context.Set<T>().SingleOrDefault(c => c.Id == id);
            if (data == null)
                data = new T();
            return View("View", data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(T data)
        {
            if (!ModelState.IsValid)
                return View("View", data);
            var record = _context.Set<T>().Where(c => c.Description.Trim().ToLower() == data.Description.Trim().ToLower() && c.Id != data.Id);
            if (record.Count() > 0)
            {
                ModelState.AddModelError($"Duplicate {typeof(T).Name}", $"{typeof(T).Name} already exist");
                return View("View", data);
            }
            if (data.Id >= 1)
            {
                T cm = _context.Set<T>().SingleOrDefault(c => c.Id == data.Id);
                cm.Description = data.Description;
                cm.UpdatedOn = DateTime.Now;
                cm.UpdatedBy = UserId;
            }
            else
            {
                _context.Set<T>().Add(data);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = 0 });
        }
