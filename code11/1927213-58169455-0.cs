    public ActionResult Create()
        {            
            var roles = Enum.GetNames(typeof(Gender))
                             .Where(f => f != Gender.Others.ToString())
                             .Select(f => new SelectListItem { Value = ((int) f).ToString(), Text = f }).ToList();
    
            ViewBag.Roles = roles;
            return View();
        }
