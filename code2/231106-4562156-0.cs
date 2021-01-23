    public class TaskWeekUI    {
       public Guid TaskWeekId { get; set; }
       public Guid TaskId { get; set; }
       public Guid WeekId { get; set; }
       public DateTime EndDate { get; set; }
       public string PersianEndDate { get; set; }
       public double? PlanProgress { get; set; }
       public double ActualProgress { get; set; }    
    } 
    
    var max = tis.Where(p => p.PlanProgress.HasValue && p.PlanProgress.Value > 0).Max(w => w.EndDate);
        tis.First( t => t.PlanProgress.HasValue && t.PlanProgress.Value > 0 && t.EndDate == max);
