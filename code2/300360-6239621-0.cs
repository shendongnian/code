    public class Derived : BreakingChange
    {
        public new void CandidateAction(string x)
        {
            base.CandidateAction(x);
        }
        
        public void CandidateAction(object o)
        {
            Console.WriteLine("Derived.CandidateAction");
        }
    }
