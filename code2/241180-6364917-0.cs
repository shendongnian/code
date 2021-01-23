    public virtual IList<GradeEntity> Grades { get; private set; }
    public CandidateEntity()
    {
         Grades = new List<GradeEntity>();
    }
