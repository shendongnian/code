    public class WeekObj
    {
        public string Week { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsValid { get; set; }
    };
    List<WeekObj> weeks= new WeekObj();
    weeks.add(new WeekObj { "week string", startDate, endDate, false });
