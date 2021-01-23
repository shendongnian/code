    public ActionResult Detail(IAnswerView AnswerModel)
    {
      // AnswerModel is only populated with the Answer Fields
      // Do Stuff with AnswerModel
      QuestionViewModel viewModel = new QuestionViewModel()
      View(viewModel);
    }
