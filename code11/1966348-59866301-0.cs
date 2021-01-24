 [HttpPost]
 public ActionResult Index(Test_Model model)
    {
       model.lstThing = new List<SelectListItem>();
       model.lstThing.Add(new SelectListItem { Text = "aaa", Value = "aaa" });
       model.lstThing.Add(new SelectListItem { Text = "bbb", Value = "bbb" });
       return View(model);
    }
You need to add back your SelectListItem items
