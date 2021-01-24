    public class Account
    {
        public int Id { get; set; }
        //Collection automatically loaded by EF
        public virtual List<Subscription> Subscriptions { get; set; }
        
        // Returns Only (or none) subscription with null End date 
        public Subscription CurrentSubscription => Subscriptions.SingleOrDefault(r=>r.End == null);
    }
