    public class UpdateFilesController : Controller
    {
        // GET: Default
        public ActionResult Edit()
        {
            var fullpath = Path.Combine(Server.MapPath("~/sourcefiles"), "paygroup.txt");
            List<string> paygroupsList = new List<string> { System.IO.File.ReadAllText(fullpath) };
            UploadFiles model = new UploadFiles
            {
                Paygroups = paygroupsList
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(string Paygroup)
        {
    
            var fullpath = Path.Combine(Server.MapPath("~/sourcefiles"), "paygroup.txt");
            if (ModelState.IsValid)
            {
                System.IO.File.WriteAllText(fullpath, Paygroup);
                ViewBag.Message = ($"{Paygroup} succesfully added");
            }
            return View();
        }
    }
