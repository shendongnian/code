    public class OsloProverModel
    {
        public string PersonalNumber { get; set; }
        public string SchoolCode { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return string.Join(",", new[] { PersonalNumber, SchoolCode, Email });
        }
    }
