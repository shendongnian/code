    completeListOfDates.Distinct(new YearMonthComparer());
    private class YearMonthComparer : IEqualityComparer<DateTime>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            if(x.Year != y.Year) return false;
            if(x.Month != y.Month) return false;
            return true;
        }
        public int GetHashCode(DateTime obj)
        {
            int hash = 13;
            hash = (hash * 7) + obj.Year.GetHashCode();
            hash = (hash * 7) + obj.Month.GetHashCode();
            reutrn hash;
        }
    }
