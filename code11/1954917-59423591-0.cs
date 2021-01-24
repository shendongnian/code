    [Table("ENTITIES")]
    public class Entity {
        [Column("ENTITY_NO")]
        public int No { set; get; }
        [Column("SEQUENCE_NO")]
        public int SequenceNo { set; get; }
        [ForeignKey("SequenceNo")] //Has to be a property name, not table column name
        public Sequence Sequence { set; get; }
        // and other properties that map correctly
    }
    [Table("SEQUENCES")]
    public class Sequence { 
        [Column("SEQUENCE_NO")]
        public int No { set; get; }
        [Column("NUMBER")]
        public int Number { set; get; }
    }
