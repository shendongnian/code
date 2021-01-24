    [Table("ENTITIES")]
    public class Entity {
        [Column("ENTITY_NO")]
        public int No { set; get; }
        [ForeignKey("Sequence")] //Has to be a property name, not table column name
        [Column("SEQUENCE_NO")]
        public int SequenceNo { set; get; }
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
