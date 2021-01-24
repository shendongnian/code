    public class Activity {
    
        ...
    
        public virtual ICollection<Approver> ApprovalStatus {get; set;}
    
        public static Func<Activity, bool> IsApproved() {
           return (Activity a) => (a.ApprovalStatus.All(x => ...) 
               && !a.ApprovalStatus.Any(x => ...);
    
        public static Func<Activity, bool> IsRejected() {
           return (Activity a) => (!a.ApprovalStatus.All(x => ...) 
               || a.ApprovalStatus.Any(x => ...);
    
        }
    }
