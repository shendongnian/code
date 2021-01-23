    var questions = from question in Entities.Questions
                    join marked in Entities.MarkedQuestions
                        on question.IDQuestion equals marked.IDQuestion
                        into marks
                    select new ModelView.MarkQuestionModel
                    {
                        AverageMark = marks.Average(x => x.Mark),
                        Text = question.Text
                    };
