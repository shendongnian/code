    List<UserExams> listUserExams = GetUserExams();
    
    var examData = 
    from userExam in listUserExams
    group by userExam.ExamID into groupExams
    select new ExamData()
    {
        ExamID = groupExams.Key,
        AverageGrade = groupExams.Average(funcMethod()),
        PassedUsersNum = groupExams.Count(e => traditionalMethod(e)),
        CompletionRate = 100 * groupExams.Count(e => /* The same long and complicated calculation */) / TotalUsersNum
    };
    // later...
    private Func<double,bool> funcMethod(){ return e=> /* your calculation */ }
    
    private bool traditionalMethod(double d){ return /* your calculation */ }
