        var questions = from sq in context.ScriptQuestions
                        where sq.ScriptId == script.ScriptId
                        select new QuestionsAnswers
                                   {
                                       QuestionId = sq.QuestionId,
                                       QuestionText = sq.Question.QuestionText,
                                       LastAnswer = sq.Question.Answers
                                           .Where(a => a.UserId == userId)
                                           .OrderByDescending(a => a.AnswerId)
                                           .Select(a => a.AnswerText)
                                           .FirstOrDefault()
                                   };
