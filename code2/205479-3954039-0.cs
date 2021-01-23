    var questionAndAnswers = questions
        .Where(x => x.Id == 3)
        .Select(x => new 
        {
            QuestionId = x.Id, 
            Question = x.Title, 
            Answer1 = x.Answers[0].Answer,
            Answer2 = x.Answers[1].Answer,
            Answer3 = x.Answers[2].Answer
        }).Single();
