    public async Task<IActionResult> UpdateExercise(Exercise exercise)
            {
                if (ModelState.IsValid)
                {
                    await this.exerciseService.EditExercise(exercise);
    
                    return RedirectToAction("UpdateIndex");
                }
                return View("Update", exercise);
            }
