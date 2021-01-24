    var questionQuery = (from a in _context.QuestionTbl.Include(q => q.QuestionGroups)
                                 select new GetQuestionViewModel()
                                 {
                                     questionID = a.questionID,
                                     questionTitle = a.questionTitle,
                                     QuestionGroups = a.QuestionGroups.Select(qg => qg.Group).ToList()
                                 
                                 })
                             .ToList();
