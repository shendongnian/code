    [HttpPost]
    public ActionResult Create(Project project)
    {
        if (ModelState.IsValid)
        {
            var org = db.Organizations.SingleOrDefault(o => o.Name.Equals(project.Organization.Name, StringComparison.CurrentCultureIgnoreCase));
            if (org != null)
            {
                project.Organization = org;
            }
            db.Projects.AddObject(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(project);
    }
