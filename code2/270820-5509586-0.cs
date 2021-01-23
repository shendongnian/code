    public class TownRecord
    {
        public int Id { get; set; }
        ...
        [ForeignKey("RecordType")]
        public int RecordTypeId { get; set; }
        public virtual TownRecordType RecordType { get; set; }
        ...
    }
