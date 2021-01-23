    public ActionResult Edit(int id){
    var model = new ProjectViewModel
    {
    Project = YourContext.Projects.SingleOrDefault(x=>x.ProjectId == id),
    Skills = YourContext.Skills.ToList()
    };
    return View(model);
    }
    
    [HttpPost]
    public ActionReissult Edit(ProjectViewModel model){
    if (ModelState.IsValid){
        
        //now you can use skills from the ViewModel
        foreach(Skill s in model.Skills){
              //you  should now have skill value.
     
