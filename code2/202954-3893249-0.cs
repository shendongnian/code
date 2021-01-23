    interface ISemester { }
    class Semester : ISemester { }
    // ...
    List<Semester> Semesters = new List<Semester>();
    var query = Semesters.ToList<ISemester>();
