    [ForeignKey("PM_COUNTRY")]
    public virtual List<PLAYERS_M> PLAYERS_M { get; set; } 
    public class COUNTRIES
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CO_ROWID { get; set; }
        public string CO_CODE { get; set; }
        public string CO_NAME { get; set; }
        [ForeignKey("PM_COUNTRY")]
        public virtual List<PLAYERS_M> PLAYERS_M { get; set; }
    }
