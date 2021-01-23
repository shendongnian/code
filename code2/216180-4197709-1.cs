    var myResultsList = GetResultsFromDatabase();
    
    var normalizedResults = myResultsList
       .SelectMany(r=>new[]{
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 1, Answer= r.Question1},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 2, Answer = r.Question2},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 3, Answer = r.Question3},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 4, Answer = r.Question4},
          new{Respondent = r.RespondentId, Admin = r.AdminId, Question = 5, Answer = r.Question5},
       };
    //finding a single answer, by respondent, admin and question:
    normalizedList.FirstOrDefault(x=>x.Respondent == 1 && x.Admin == 2 && x.Question == 1);
