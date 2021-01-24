cs
    public JsonResult getProjects()
    {
            // Code omitted
            var projects = dc.Projects.Include(p => p.ProjectType)
                 .Select(p => new {
                     Id = p.Id,
                     ProjectType = new {
                         Id = p.ProjectType.Id,
                     }
                 });
            return Json(projects.ToList(), "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
    }
The second option: (Although, this just hides the problem and doesn't actually solve it.) 
cs
services.AddMvc().AddJsonOptions(opts =>
     opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
