    public class ClockPunch
    {
        private DateTimeOffset dtoTimeIn;
        private DateTimeOffset? dtoTimeOut;
        public ClockPunch() { }
        public DateTimeOffset TimeIn
        {
            get { return dtoTimeIn.ToCentralTime(); }
            set { dtoTimeIn = value; }
        }
        public DateTimeOffset? TimeOut
        {
            get
            {
                DateTimeOffset? retVal = null;
                if (dtoTimeOut != null)
                {
                    retVal = ((DateTimeOffset)dtoTimeOut).ToCentralTime();
                }
                return retVal;
            }
            set { dtoTimeOut = value; }
        }
    }
