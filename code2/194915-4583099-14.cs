    [HttpPost]
    public ActionResult Create(QuestionForm quesfrm)
    {
     IRepository<Question> qRepo = RepositoryFactory.GetQuestionRepo();
     Question ques = new Question {
     AskedDate = DateTime.Now,
     Title = quesfrm.Title,
     Content = QuestionContent
     }
      qRepo.Save(ques);
    }
