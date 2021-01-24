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
