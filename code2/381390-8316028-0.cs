    public IQuestionDetail
    {
      string QuestionText { get; }
      // Question Details
    }
    public IQuestionView
    {
      IQuestionDetail QuestionDetail { get; }  
    }
    public IAnswerDetail
    {
      int/guid QuestionID { get; }
      string AnwerText { get; }
      // Anwer Details
    }
    public IAnswerView
    {
      IAnswerDetail AnswerDetail { get; }  
    }
