    public class ScheduleItem : IComparable<ScheduleItem>
    {
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int CompareTo(ScheduleItem item)
        {
            return Title.CompareTo(item.Title);
        }
    }
