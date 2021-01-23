    public class Questions {
    
        public int QuestionID { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public string SubQuestionSequence { get; set; }            
        public SubQuestion { get; set; }
    }
    
    public class SubQuestion {
    
        public string Keywords { get ; set ; }
        public int ParentQuestionID { get; set; }
    
    }
