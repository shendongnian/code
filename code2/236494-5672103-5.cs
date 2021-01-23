        //
        // GET: /Family/Create
        public ActionResult Create()
        {
            return View();
        } 
        //
        // POST: /Family/Create
        [HttpPost]
        public ActionResult Create(FamilyViewModel familyViewModel)
        {
            try
            {
                Family family = new Family();
                family.InjectFrom<UnflatLoopValueInjection>(familyViewModel);
                db.Families.Add(family);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
