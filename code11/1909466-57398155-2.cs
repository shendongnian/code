    public class Properties
    {
        public int EntryID { get; set; }
    
        public string Position { get; set; }
    
        public DateTime? PositionDateEnd { get; set; }
    
        private DateTime? _positionDateStart;
        public DateTime? PositionDateStart
        {
           get { return _positionDateStart == null ? DateTime.Now : _positionDateStart; }
           set { _positionDateStart = value; }
        }
    }
