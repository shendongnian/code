    [HttpPost]
    public ActionResult Edit([Bind(Exclude = "GradeId")]Grade grade)
    {
      MvcApplication.Container.BuildUp(grade);
            
      //Add this to your controller.
      TryValidateModel(grade);
            
      if (!ModelState.IsValid)
      {
        return View("Edit", grade);
      }
      try
      {
        var provider = MvcApplication.Container.Resolve<IGradeProvider>();
        provider.Edit(grade);
        return RedirectToAction("Details", "Grade", new { id = grade.GradeId });
      }
      catch
      {
        return RedirectToAction("Index");
      }
    }
