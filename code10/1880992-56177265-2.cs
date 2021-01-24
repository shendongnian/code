    [Serializable]
    public class SearchCriteria
    {
        public int? Id { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Name { get; set; }
    }
    private void ByParameters(SearchCriteria criteria)
    {
        // ....
    }
