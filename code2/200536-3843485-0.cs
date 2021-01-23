    using (var dataContext = new DataContext(connString)) {
      questionsTable=
                 from q in dataContext.GetTable<Questions>()
                 from a in dataContext.GetTable<Answers>()
                 from qa in dataContext.GetTable<QuestionsAndAnswers>()
                 where qa.QuestionID == q.QuestionID && qa.AnswerID == a.AnswerID
                 select new { Question = q, Answer = a};
    }
