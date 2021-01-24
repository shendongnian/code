     public class customerComplex
    {
        public string cFName { get; set; }
        public string cLName { get; set; }
        public int cSex { get; set; }
        public string aId { get; set; }
        public string cId { get; set; }
        public int stars { get; set; }
        public IQueryable<customerComplex> GetValues()
        {
            return new List<customerComplex>().AsQueryable();
        }
    }
