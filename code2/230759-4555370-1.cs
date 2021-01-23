    public List<QuestionResult> GetLatestResult(Guid QuizID, string UserName) {
        return (
               from q in db.QuizResults
               where q.QuizId == QuizID && q.UserName == UserName
               group q by q.QuestionId into grouped
               select new QuestionResult {
                   QuestionId = grouped.Key,
                   AnswerId = grouped.OrderByDescending(q => q.CompletionDate).First().AnswerId
               };
           ).ToList();
    }
