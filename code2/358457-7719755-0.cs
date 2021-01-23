    public class Job {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        int Id { get; set; }
        DateTime StartTime { get; set; }   // other fluff values here
        User User { get; set; }
    }
