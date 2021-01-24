    [HttpGet]
    public ActionResult EditDiscipline()
    {
        var disciplinesList = _idiscipline.disciplines();
        var vm = new DisciplineViewModel
         {
               DisciplineList  = disciplinesList;
         }
        return View(vm);
    }
    
