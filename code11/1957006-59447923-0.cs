    [HttpGet]
    public async Task<IActionResult> Update(int exerciseId)
    {
        Exercise exercise = (await this.exerciseService.GetExercises(exercise => exercise.Id == exerciseId)).FirstOrDefault();
        return View(exercise);
    }
    
    [HttpPut]
    [ActionName("Update")]
    public async Task<IActionResult> UpdatePut(Exercise exercise)
    {
        if (ModelState.IsValid)
        {
            await this.exerciseService.EditExercise(exercise);
            return RedirectToAction("some-view-which-doesnt-matter-in-my-case");
        }
        return View(exercise);
    }
