    public void SomeMethod()
    {
      Answers.IsAnswered += new Action<bool>(Answers_IsAnsweredCompleted);
    }
    
    public void Answers_IsAnsweredCompleted(bool IsAsnwered)
    {
      //call your method in QuizMaster
    }
