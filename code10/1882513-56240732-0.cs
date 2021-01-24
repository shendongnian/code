    public class LotHistoryInfo
    {
        public Location Location { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public LotHistoryInfo(LotStoreHistory his)
        {
            Location = new Location(his.LshStoreid.ToString(), his.LshStorex, his.LshStorey, his.LshStorez);
            UpdatedBy = his.UpdatedBy;
            UpdateDate = his.Updated;
        }
        public LotHistoryInfo()
        {
        }
    }
