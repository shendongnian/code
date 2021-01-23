    var surveyRepository = new SurveyRepository();
    surveyRepository.InsertOrUpdate(survey);
    foreach (var userAnswer in userAnswers)
    {
       survey.UserAnswers.Add(userAnswer);
    }
    surveyRepository.Save();
