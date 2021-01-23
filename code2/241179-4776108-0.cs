    List<Grade> Grades { 
         get { return _grades; }
         set { _grades = value; OnGradesChanged(); }
    protected virtual OnGradesChanged()
    { }
