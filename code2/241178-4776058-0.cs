    private IList<GradeEntity> _grades
    
    public virtual IList<GradeEntity> Grades
    {
       get { return _grades; }
       set { _grades = value; }
    }
    
    public CandidatesEntity()
    {
       _grades = new List<GradeEntity>();
    }
