     var surveyRepository = new SurveyRepository();
     foreach (var userAnswer in userAnswers)
     {
    +    userAnswer.SurveyId = Survey.Id;
         survey.UserAnswers.Add(userAnswer);
     }
     surveyRepository.InsertOrUpdate(survey);
     surveyRepository.Save();
