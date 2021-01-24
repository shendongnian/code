    var questionMessages = QuestionList.GroupJoin(MessagesList,
                    q => q.QuestionID,
                    m => m.QuestionID,
                    (Question, Messages) => new { Question, Messages }
                );
    var groupJoin = SectionList.GroupJoin(questionMessages,
                    sct => sct.SectionID,
                    s => s.Question.SectionID,
                    (sct, QuestionsGroup) => new
                    {
                        Questions = QuestionsGroup,
                        SectionName = sct.SectionName
                    });
