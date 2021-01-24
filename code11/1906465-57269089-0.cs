    var group1 = SectionList.Select(section => new Section
    {
        SectionID = section.SectionID,
        SectionName = section.SectionName,
        Questions = QuestionList.Where(question => question.SectionID.Equals(section.SectionID))
            .Select(question => new Question
            {
                QuestionID = question.QuestionID,
                QuestionName = question.QuestionName,
                SectionID = section.SectionID,
                Messages = MessagesList.Where(message => message.QuestionID.Equals(question.QuestionID))
                    .Select(message => new Messages
                    {
                        MessagesID = message.MessagesID,
                        MessagesName = message.MessagesName,
                        QuestionID = message.QuestionID
                    })
            })
    });
