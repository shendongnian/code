    group by user.UserID
    select new
    {
       User = user.UserID
       TotGradeCount = workRew.Grade.Sum()
       Graders = workRew.Grade.Count()
    }
