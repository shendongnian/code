    public class ScheduleView
    {
        public Schedule Schedule { get; set; }
        public Visit Visit { get; set; }
        **public Patient Patient{ get; set; }**
    }
        var query = Context.Schedule.Join(Context.Visit
        ,/*Schedule join key definition*/,/*Visit join key definition*/,
        (scheduleView, visit) => new ScheduleView 
    {Schedule = scheduleView, Visit = visit, **Patient = visit.Patient**})
