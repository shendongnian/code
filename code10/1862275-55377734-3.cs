    public class SomeDTOType {
        public int id {get; set;}
        public int qid {get; set;}
        public string qname {get; set;}
        public int qtype {get; set;}
    }
    var questions = dbContext.Sft_Set.Where(s => s.Sft_Set_ID == currentSet)
                  .Select(s => new
                  SomeDTOType {  // <===============================
                      id = s.Sft_Set_ID,
                      qid = s.Sft_QuestionID,
                      qName = s.Sft_Question.Q_Question,
                      qtype = s.Sft_Question.Q_Type
                  }).ToList();
    Session["questionList"] = questions;
    var list = Session["questionList"] as List<SomeDTOType>; 
