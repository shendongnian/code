    class CustomDate
    {
        public DateTime Date { get; set; }
        public bool IsTimeOnly { get; private set; }
        public CustomDate(bool isTimeOnly)
        {
            this.IsTimeOnly = isTimeOnly;
        }
        public string GetValue()
        {
            if (IsTimeOnly)
            {
                return Date.ToShortTimeString();
            }
            else
            {
                return Date.ToString();
            }
        }
    }
