    public class Alarme
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            public DateTime? DataDisparado { get; set; }//.This allow you to work with nullable datetime in database.
            public DateTime? DataResolvido { get; set; }//.This allow you to work with nullable datetime in database.
            public long Latencia { get; set; }
            
            public bool Resolvido { get; set; }
    
            public int SensorId { get; set; }
            [ForeignKey("SensorId")]
            public virtual Sensor Sensor { get; set; }
        }
