    public class MyModel
    {
        public List<Group> Group { get; set; }
        public List<Season> Season { get; set; }
        public List<Age> Age { get; set; }
        public List<VirusType> VirusType { get; set; }
        public List<VirusData> VirusData { get; set; }
        public List<Config> Config { get; set; }
        public List<LastWeek> LastWeek { get; set; }
    }
    public class Group
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    public class Season
    {
        public int SeasonID { get; set; }
        public string Description { get; set; }
        public int StartWeek { get; set; }
        public int EndWeek { get; set; }
        public bool Enabled { get; set; }
        public string Label { get; set; }
        public bool ShowLabType { get; set; }
    }
    public class Age
    {
        public int AgeID { get; set; }
        public string Label { get; set; }
        public string Color_HexValue { get; set; }
        public bool Enabled { get; set; }
    }
    public class VirusType
    {
        public int VirusID { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public int StartMMWRID { get; set; }
        public int EndMMWRID { get; set; }
        public int DisplayOrder { get; set; }
        public string ColorName { get; set; }
        public string Color_HexValue { get; set; }
        public int LabTypeID { get; set; }
        public int SortID { get; set; }
    }
    public class VirusData
    {
        public int VisrusID { get; set; }
        public int AgeID { get; set; }
        public int Count { get; set; }
        public int MMWRID { get; set; }
        public int Seasonid { get; set; }
        public int PublishYearWeekID { get; set; }
        public string LoadDateTime { get; set; }
    }
    public class Config
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
    public class LastWeek
    {
        public int MMWRID { get; set; }
        public DateTime WeekEnd { get; set; }
        public int WeekNumber { get; set; }
        public DateTime WeekStart { get; set; }
        public int Year { get; set; }
        public string YearWeek { get; set; }
        public int SeasonID { get; set; }
    }
