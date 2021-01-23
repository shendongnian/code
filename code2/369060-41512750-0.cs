    public class Faturamento {
            [Column("ID_OSSB")]
            public virtual int ID_OSSB { get; set; }
            [ForeignKey("ID_OSSB")]
            public virtual OSSB OSSB { get; set; }
            ...
    }
