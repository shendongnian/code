    public class TrackRecordVM
    {
        public decimal? Jan { get; set; }
        public decimal? Feb { get; set; }
        public decimal? Not { get; set; }
        public IEnumerable<decimal?> GetMonths()
        {
            yield return Jan;
            yield return Feb;
        }
    }
