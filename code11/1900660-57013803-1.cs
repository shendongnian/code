    public class IterationViewModel
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Active 
        { 
            get { return DateTime.Now.Date >= this.Start.Date && DateTime.Now.Date <= this.End.Date; } 
        }
    }
