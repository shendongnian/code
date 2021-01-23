    public class Part
    {
        public List<int> Values
        {
            get;
            set;
        }
        public int CurrentSum
        {
            get;
            set;
        }
        /// <summary>
        /// Default Constructpr
        /// </summary>
        public Part()
        {
            Values = new List<int>();
        }
        public void AddValue(int value)
        {
            Values.Add(value);
            CurrentSum += value;
        }
    }
