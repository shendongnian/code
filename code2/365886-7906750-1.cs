    public class Day : INotifyPropertyChanged
    {
        // Of course, these should implement the usual PropertyChange Notifications
        public int WeekNo {get; set;}
        public int WeekDay {get; set;}
        public DateTime  Date {get; set;}
    }
