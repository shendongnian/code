    public class Audit
    {
        [Key]
        public long Pk { get; set; }
        
        [NotMapped]
        public string PkString => Pk.ToString();
            
        public string TableName { get; set; }
            
        public string RowPk { get; set; }
            
        public string ActionType { get; set; }
            
        public string RowContent { get; set; }
    }
