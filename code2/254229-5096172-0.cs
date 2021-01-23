    public class LastIntervalUpdated
    {
        public bool IsLastIntervalNewer
        {
            get
            {
                return this.dbPostTime_EST == null || this.retrievalTime_EST > this.dbPostTime_EST
            }
        }
        //other properties...
    }
