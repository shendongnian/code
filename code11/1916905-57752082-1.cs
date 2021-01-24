     public class Suite
        {
            //another property
            public int IdSuite { get; set; }
            public virtual ICollection<SuitQuestions> Questions { get; set; }
        }
        public class Question
        {
            //another property
            public int IdQuestion { get; set; }
            public virtual ICollection<SuitQuestions> Suites { get; set; }
        }
        public class SuiteQuestions
        {
            public Suite Suite { get; set; }
            public int IdSuite { get; set; }
            public  Question Question { get; set; }
            public int IdQuestion { get; set; }
            //add custome property if you need
           
        }
