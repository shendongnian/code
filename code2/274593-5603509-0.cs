    public class ReducedAnswer
    {
        public int vountcount { get; set; }
        public bool isSelected { get; set; }
       
        public ReducedAnswer()
        {
        }
    }
    ReducedAnswer firstAnswer = p.Answers.Select(z => new ReducedAnswer { vountcount = z.vountcount, isSelected = z.isSelected }).FirstOrDefault();
