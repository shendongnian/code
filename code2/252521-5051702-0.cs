    public class RssController: Controller
    {
        public ActionResult Extract()
        {
            var model = new ExtractModel();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Begin(string url)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Extracted", new { url = url });
            }
            return View();
        }
    }
