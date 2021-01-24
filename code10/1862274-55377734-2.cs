    var questions = dbContext.Sft_Set.Where(s => s.Sft_Set_ID == currentSet)
                  .Select(s => new
                  Sft_Set {  // <===============================
                      id = s.Sft_Set_ID,
                      qid = s.Sft_QuestionID,
                      qName = s.Sft_Question.Q_Question,
                      qtype = s.Sft_Question.Q_Type
                  }).ToList();
    Session["questionList"] = questions;
    var list = Session["questionList"] as List<Sft_Set>; 
