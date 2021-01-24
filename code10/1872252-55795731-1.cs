    public class PrintTheQ
    {
        public DateTime LastStatusUpdate { get; set; }
        public DateTime AddedToQueue { get; set; }
        public int DayDiff
        {
            get {return (int)(LastStatusUpdate - AddedToQueue).TotalDays;}
        }
    }
