    public ActionResult Save(HttpFormCollection formCollection)
    {
      var saveModel = new SaveModel(); // or from a Factory etc
      var validModel = TryUpdateModel(_saveModel, formCollection); // order may be incorrect
      return validModel ? Save(saveModel) : InvalidSaveModel(saveModel);
    }
