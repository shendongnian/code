    public class FResult
    {
        public FResult(int id1, int id2, ..., int sc)
        {
            Match1 = new Match(id1, ...);
            Match2 = new Match(id2, ...);
            this.sc = sc;
        }
    
        public Match Match1 { get; set; }
        public Match Match2 { get; set; }
        public int sc { get; set; }
    }
