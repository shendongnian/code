       public class ProgrammeRow
       {
            public int ProgrammeId { get; set; }
            public string ProgrammeName { get; set; }
            public int StudentId { get; set; }
            public virtual Student Student{ get; set; }
       }
    
       public class Programme
       {
            public int ProgrammeId { get; set; }
            private ICollection<ProgrammeRow> _rows;
            public virtual ICollection<ProgrammeRow> Rows => _rows ?? (_rows = new List<ProgrammeRow>());
       }
