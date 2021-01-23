    var myResultsList = GetResultsFromDatabase();
    
    var resultsByRespondent = myResultsList
       .SelectMany(r=>new[]{
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 1, Answer= r.Question1},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 2, Answer = r.Question2},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 3, Answer = r.Question3},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 4, Answer = r.Question4},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 5, Answer = r.Question5},
       };
