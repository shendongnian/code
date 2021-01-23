    class YOURCUSTOMCLASS
    {
        private DateTime creationTime;
        public DateTime CreationTime
        { get { return creationTime; } }
  
        public YOURCUSTOMCLASS(parametersGoesHere xyz)
        {
              creationTime = DateTime.Now;
        }
        /// in this case this method will return true
        /// if the timeSpan between this object and otherObject
        /// is greater than 4 seconds
        public bool CheckForInterval(YOURCUSTOMCLASS otherObject)
        {
             TimeSpan diff = otherObj.CreationTime.Subtract(creationTime);
             /// you may replace 4 through any other digit, or even better take
             /// a const/global var/static ...
             return diff.TotalSeconds > 4;
        }
        /// all the other stuff you need ...
    }
