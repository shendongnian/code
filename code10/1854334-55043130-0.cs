    public class ScoutDataEvent
    {
        [PrimaryKey]
        public int ID { get; set; }
        [NotNull]
        public int EventID { get; set; }
        [NotNull]
        public int ScoutDataID { get; set; }
    }
