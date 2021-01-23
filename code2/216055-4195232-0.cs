    try
    {
      UpdateModel(evaluation, "evaluation");
      //"Update to db" code
    }
    catch
    {
      Evaluation.ViewModels.EvaluationEditViewModel viewModel = new    
      Evaluation.ViewModels.EvaluationEditViewModel();
      viewModel.evaluation = evaluation;
      return View(viewModel);
    }
