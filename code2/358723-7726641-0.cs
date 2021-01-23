    class JournalComparer : IEqualityComparer<WorkingJournal>
    {
        public bool Equals(WorkingJournal left, WorkingJournal right)
        {
             // perform your equality semantics here
        }
    
        public int GetHashCode(WorkingJournal obj)
        {
             // return some hash code here.
             return obj.ServicePlan.GetHashCode();
        }
    }
    var comparer = new JournalComparer(); // implements the interface 
    var result = workRosters.Select(...).Distinct(comparer);
