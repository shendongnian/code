    public partial class User : UserBase
    {
        public Guid UserId { get; set; }
        public int PeopleId { get; set; }
        public int EpothecaryUserId { get; set; }
        public string PersonFullName { get; set; }
        public SearchGroups SearchGroups { get; set; }
        public string SearchHistoryString { get; set; }
        public int SearchRowsReturnedPerGroup { get; set; }
    }
