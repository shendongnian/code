    public class ActivitySummary
    {
        public int ActID { get; set; }
        public string ActTitle { get; set; }
        public string Category { get; set; }
        public DateTime ActDateTime { get; set; }
        public string Location { get; set; }
    }
. . .
    List<ActivitySummary> activities;
    using (MyEntities context = new MyEntities())
    {
        activities = from act in context.Activities
                     where act.ActTwittered == false
                     select new ActivitySummary { act.ActID, act.ActTitle, act.Category, act.ActDateTime, act.Location }.ToList();
    
    }
    foreach (var activity in activities)
    {
        /* ... */
    }
