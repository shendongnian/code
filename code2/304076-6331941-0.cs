    List<UserExams> listUserExams = GetUserExams();
    
    var examData = 
        from userExam in listUserExams
        group by userExam.ExamID into groupExams
        let passCount = groupExams.Count( /* long expression */)
        select new ExamData()
        {
            ExamID = groupExams.Key,
            AverageGrade = groupExams.Average(e => e.Grade),
            PassedUsersNum = passCount,
            CompletionRate = 100 * passCount / TotalUsersNum
        };
