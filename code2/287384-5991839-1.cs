    [Table(Name = "Countries")]    
    public class Country
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int CountryId { get; set; }
        [Column]
        public string iso2 { get; set; }
        [Column]
        public string iso3 { get; set; }
        [Column]
        public string name_en { get; set; }
    }
