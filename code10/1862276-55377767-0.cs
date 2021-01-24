    public class Question
    {
       public int id {get;set;} // or whatever datatype your id is
       public int qid {get;set;} // or whatever datatype your qid is
       public string qName {get;set;} // chose a datatype that makes sense here
       public string qType {get;set;} // chose a datatype that makes sense here
    }
    
    /// .....
    
    var questions = dbContext.Sft_Set.Where(s => s.Sft_Set_ID == currentSet)
                      .Select(s => new Question
                      {
                          id = s.Sft_Set_ID,
                          qid = s.Sft_QuestionID,
                          qName = s.Sft_Question.Q_Question,
                          qtype = s.Sft_Question.Q_Type
                      }).ToList();
    
    Session["questionList"] = questions;
    var list = Session["questionList"] as List<Question>; 
