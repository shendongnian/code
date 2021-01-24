    var jsonBody = new ObjectRoot()
    {
        productId = "productId",
        questions = new[]
        {
            new Question() {
                questionId = "b2b-2.01",
                question ="Vad är syftet med ert engagemang hos oss?",
                helpText = null,
                questionType = "MultiChoise",
                answerChoices = new []{
                    new AnswerChoice{
                        answerChoiceId = "",
                        value = "",
                        subQuestions = new List<object>() // empty collection                        
                    }
                }.ToList(),
                answers = new List<object>()
            }
        }.ToList()
    };
