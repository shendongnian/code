    public class STUDENTS
    {
        public STUDENTS()
        {
            COURSES = new List<COURSES>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ST_ROWID { get; set; }
        public int ST_NAME { get; set; }
        [ForeignKey("CR_SM_REFNO")]
        public virtual List<COURSES> COURSES { get; set; }
    }
    public class COURSES
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CR_ROWID { get; set; }
        public string CR_NAME { get; set; }
        public int CR_SM_REFNO { get; set; }
        [ForeignKey("CR_SM_REFNO")]
        public virtual STUDENTS STUDENTS { get; set; }
    }
