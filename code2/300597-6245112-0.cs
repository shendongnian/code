    var questions =
        from question in Entities.Questions 
        select
            new
            {
                question.Text,
                AverageMark = Entities.MarkedQuestions
                    .Where(arg => arg.IDQuestion == question.IDQuestion)
                    .Average(arg => arg.Mark)
            };
