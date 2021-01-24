     public class Question
        {
            public string question { get; set; }
            public string[] option { get; set; }
            public string[] score { get; set; }
    
            public Question(string question, List<string> option, List<string> score)
            {
                this.question = question;
                this.option = option.ToArray();
                this.score = score.ToArray();
    
            }
        }
