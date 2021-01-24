    public class Attendance
    {
        public int WeddingId {get; set;}
        public int CountOfUsers {get; set;
    }
    var attendance = context.UserWeddings.GroupBy(c => c.WeddingId).Select(grp => 
                     new Attendance 
                     {
                         WeddingId = grp.Key, //will be grouped by WeddingId,
                         CountOfUsers = grp.Select(c => c.UserId).Distinct().Count()
                         //added select userid and distinct to count unique users 
                         //attending the wedding id
                     }).ToList();
