    var QuestionMessages = QuestionList.GroupJoin(MessagesList,
                    q => q.QuestionID,
                    m => m.QuestionID,
                    (Question, Messages) => new { Question, Messages }
                );
