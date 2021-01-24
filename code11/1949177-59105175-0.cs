    <input type="hidden" name="mylist" value="@TempData["List"]">
 
     [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Experiment1(ExperimentViewmodel experiment,mylist[])
    {
        var newExperiment = new Experiment
        {
            Question1 = experiment.SelectededItem
        };
        if (ModelState.IsValid)
        {
            _context.Update(newExperiment);
            await _context.SaveChangesAsync();
            var stringList = mylist as List<string>; 
            var nextExperiment = stringList.FirstOrDefault(); 
            stringList.RemoveAt(0);                           
            TempData["List"] = stringList;                  
            return RedirectToAction(nextExperiment, new { id = newExperiment.EID });
        }
        return View();
    }
