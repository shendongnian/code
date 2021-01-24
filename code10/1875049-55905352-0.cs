    public class LeadPerformanceItemCollection : List<LeadPerformanceItem>
    {
        
        public new void Add(LeadPerformanceItem item)
        {
            //calculate percent of total here
            base.Add(item);
        }
    }
