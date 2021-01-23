     public class StrippedDate : IComparable<StrippedDate>, IComparable
    {
        public DateTime Date { get; private set; }
        public StrippedDate(DateTime date)
        {
            Date = date;
        }
        public int CompareTo(StrippedDate other)
        {
            //you can simply compare
            if (Date.Year == other.Date.Year &&
                Date.Month == other.Date.Month &&
                Date.Day == other.Date.Day) return 0;
            //Put your logic to compare 
            return Date.CompareTo(other.Date);
        }
        public override int GetHashCode()
        {
            //TODO:
            //Write better hash logic
            return Date.Year.GetHashCode() <<
                   Date.Month.GetHashCode() <<
                   Date.Month.GetHashCode() >> 0x41;
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
  
    public class StripedDateDictionary : IEnumerable<StrippedDate>
    {
        private readonly Dictionary<StrippedDate, IList<float>> dictionary;
        public StripedDateDictionary(Dictionary<StrippedDate, IList<float>> dictionary)
        {
            this.dictionary = dictionary;
        }
        public void Add(StrippedDate key, float[] values)
        {
            dictionary.Add(key, new List<float>(values));
        }
        public float[] this[StrippedDate index]
        {
            get
            {
                return null;
            }
            set
            {
                /* set the specified index to value here */
            }
        }
        public float[] this[DateTime time]
        {
            get
            {
                StrippedDate date = new StrippedDate(time);
                return this[date];
            }
            set { throw new NotImplementedException("Setter not implemented"); }
        }
        public IEnumerator<StrippedDate> GetEnumerator()
        {
            return dictionary.Select(pair => pair.Key).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
