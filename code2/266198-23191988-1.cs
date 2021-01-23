    public class QuestionNode
        {
            public decimal QuestionCode { get; set; }
            public decimal parentQuestionCode { get; set; }        
            public string AssessmentSection { get; set; }
            public string shortName { get; set; }
            public List<QuestionNode> ChildQuestionNode { get; set; }
        }
