    var groupJoin = SectionList.GroupJoin(QuestionMessages,
                    sct => sct.SectionID,
                    s => s.Question.SectionID,
                    (sct, QuestionsGroup) => new
                    {
                        Questions = QuestionsGroup,
                        SectionName = sct.SectionName
                    });
                foreach (var item in groupJoin)
                {
                    Console.WriteLine(item.SectionName);
                    foreach (var stud in item.Questions)
                    {
                        Console.WriteLine($" - {stud.Question.QuestionName}");
                        foreach (var message in stud.Messages)
                        {
                            Console.WriteLine($"  -- {message.MessagesName}");
                        }
                    }
                }
