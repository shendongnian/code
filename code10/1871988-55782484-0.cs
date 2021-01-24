    public class Document
    {
        IList<Periods> periods;
        public virtual IList<Period> Periods
        {
            get { return periods; }
            set { periods = value; }
        }
        public virtual void ResetPeriods()
        {
            periods = new List<Period>();
        }
    }
