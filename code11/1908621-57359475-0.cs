              List<QuestionsAndChoices> questionsAndChoices1 = (from qandc in context.quizQuestionAndChoices
                                                                  join quest in context.quizQuestions on qandc.QuizQuestionsId equals quest.QuizQuestionsId
                                                                  join answers in context.quizChoices on qandc.QuizChoicesId equals answers.QuizChoicesId
                                                                  select new { question = quest.Questions, answers = answers })
                                                                 .GroupBy(x => x.question)
                                                                 .Select(x => new QuestionsAndChoices()
                                                                 {
                                                                     Question = x.Key,
                                                                     Choices = x.Select(y => y.answers).FirstOrDefault()
                                                                 }).ToList();
